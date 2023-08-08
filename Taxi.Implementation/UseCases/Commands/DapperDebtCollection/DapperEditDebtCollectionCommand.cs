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
    public class DapperEditDebtCollectionCommand : DapperUseCase, IEditDebtCollectionCommand
    {
        private EditDebtCollectionValidator _validator;
        public DapperEditDebtCollectionCommand(DapperContext context, IApplicationUser user, EditDebtCollectionValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 35;

        public string Name => "Edit DebtCollection";

        public string Description => "Edit DebtCollection";

        public void Execute(DebtCollectionDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  DebtCollections 
                    SET 
                    DebtCollectionPrice = @DebtCollectionPrice,
                    DebtorId = @DebtorId,
                    EditedAt = @EditedAt
                    WHERE Id = @Id";

                DynamicParameters param = new DynamicParameters();
                param.Add("@DebtCollectionPrice", request.DebtCollectionPrice);
                param.Add("@DebtorId", request.DebtorId);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
