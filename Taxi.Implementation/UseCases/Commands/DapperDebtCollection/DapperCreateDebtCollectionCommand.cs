using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.DebtCollection;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperDebtCollection
{
    public class DapperCreateDebtCollectionCommand : DapperUseCase, ICreateDebtCollectionCommand
    {
        private CreateDebtCollectionValidator _validator;
        public DapperCreateDebtCollectionCommand(DapperContext context, IApplicationUser user, CreateDebtCollectionValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 34;

        public string Name => "Create DebtCollection";

        public string Description => "Create DebtCollection";

        public void Execute(CreateDebtCollectionDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO DebtCollections 
                    (DebtCollectionPrice, DebtorId)
                    VALUES (@DebtCollectionPrice, @DebtorId)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@DebtCollectionPrice", request.DebtCollectionPrice);
                param.Add("@DebtorId", request.DebtorId);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
