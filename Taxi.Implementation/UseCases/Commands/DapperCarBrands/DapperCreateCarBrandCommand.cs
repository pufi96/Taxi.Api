using Dapper;
using FluentValidation;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.CarBrand;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperCarBrands
{
    public class DapperCreateCarBrandCommand : DapperUseCase, ICreateCarBrandCommand
    {
        private CreateCarBrandValidator _validator;
        public DapperCreateCarBrandCommand(DapperContext context, IApplicationUser user, CreateCarBrandValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 27;

        public string Name => "Create CarBrand";

        public string Description => "Create CarBrand";

        public void Execute(CreateCarBrandDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO CarBrands 
                    (CarBrandName)
                    VALUES (@CarBrandName)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@CarBrandName", request.CarBrandName);

                connection.Execute(insertQuery, param);
            }

        }
    }
}
