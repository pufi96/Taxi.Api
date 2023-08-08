using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.LocationPrice;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperLocationPrices
{
    public class DapperEditLocationPriceCommand : DapperUseCase, IEditLocationPriceCommand
    {
        private EditLocationPriceValidator _validator;
        public DapperEditLocationPriceCommand(DapperContext context, IApplicationUser user, EditLocationPriceValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 39;

        public string Name => "Edit LocationPrice";

        public string Description => "Edit LocationPrice";

        public void Execute(LocationPricesDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  LocationPrices 
                    SET 
                    LocationStart = @LocationStart,
                    LocationEnd = @LocationEnd,
                    Price = @Price,
                    EditedAt = @EditedAt
                    WHERE Id = @Id";

                DynamicParameters param = new DynamicParameters();
                param.Add("@DebtorFirstName", request.LocationStart);
                param.Add("@DebtorLastName", request.LocationEnd);
                param.Add("@Description", request.Price);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
