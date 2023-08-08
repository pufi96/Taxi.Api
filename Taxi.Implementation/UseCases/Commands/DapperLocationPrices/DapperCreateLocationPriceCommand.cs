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
    public class DapperCreateLocationPriceCommand : DapperUseCase, ICreateLocationPriceCommand
    {
        private CreateLocationPriceValidator _validator;
        public DapperCreateLocationPriceCommand(DapperContext context, IApplicationUser user, CreateLocationPriceValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 38;

        public string Name => "Create LocationPrice";

        public string Description => "Create LocationPrice";

        public void Execute(CreateLocationPricesDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO LocationPrices 
                    (LocationStartId, LocationEndId, Price)
                    VALUES (@LocationStartId, @LocationEndId, @Price)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@LocationStartId", request.LocationStartId);
                param.Add("@LocationEndId", request.LocationEndId);
                param.Add("@Price", request.Price);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
