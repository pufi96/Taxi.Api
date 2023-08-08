using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.CarModel;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperCarModels
{
    public class DapperCreateCarModelCommand : DapperUseCase, ICreateCarModelCommand
    {

        private CreateCarModelValidator _validator;
        public DapperCreateCarModelCommand(DapperContext context, IApplicationUser user, CreateCarModelValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 29;

        public string Name => "Create CarModel";

        public string Description => "Create CarModel";

        public void Execute(CreateCarModelDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO CarModels 
                    (CarModelName, CarBrandId)
                    VALUES (@CarModelName, @CarBrandId)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@CarModelName", request.CarModelName);
                param.Add("@CarBrandId", request.CarBrandId);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
