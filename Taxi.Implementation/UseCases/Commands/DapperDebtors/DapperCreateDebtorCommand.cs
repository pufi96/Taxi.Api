using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Debtor;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperDebtors
{
    public class DapperCreateDebtorCommand : DapperUseCase, ICreateDebtorCommand
    {
        private CreateDebtorValidator _validator;
        public DapperCreateDebtorCommand(DapperContext context, IApplicationUser user, CreateDebtorValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 36;

        public string Name => "Create Debtor";

        public string Description => "Create Debtor";

        public void Execute(CreateDebtorDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO Debtors 
                    (DebtorFirstName, DebtorLastName, Description)
                    VALUES (@DebtorFirstName, @DebtorLastName, @Description)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@DebtorFirstName", request.DebtorFirstName);
                param.Add("@DebtorLastName", request.DebtorLastName);
                param.Add("@Description", request.Description);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
