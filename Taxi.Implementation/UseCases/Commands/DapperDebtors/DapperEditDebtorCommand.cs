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
    public class DapperEditDebtorCommand : DapperUseCase, IEditDebtorCommand
    {
        private EditDebtorValidator _validator;
        public DapperEditDebtorCommand(DapperContext context, IApplicationUser user, EditDebtorValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 37;

        public string Name => "Edit Debtor";

        public string Description => "Edit Debtor";

        public void Execute(DebtorDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  DebtCollections 
                    SET 
                    DebtorFirstName = @DebtorFirstName,
                    DebtorLastName = @DebtorLastName,
                    Description = @Description,
                    EditedAt = @EditedAt
                    WHERE Id = @Id";

                DynamicParameters param = new DynamicParameters();
                param.Add("@DebtorFirstName", request.DebtorFirstName);
                param.Add("@DebtorLastName", request.DebtorLastName);
                param.Add("@Description", request.Description);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
