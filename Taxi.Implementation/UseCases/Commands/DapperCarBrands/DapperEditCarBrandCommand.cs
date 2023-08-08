using Dapper;
using FluentValidation;
using System;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.CarBrand;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperCarBrands
{
    public class DapperEditCarBrandCommand : DapperUseCase, IEditCarBrandCommand
    {
        private EditCarBrandValidator _validator;
        public DapperEditCarBrandCommand(DapperContext context, IApplicationUser user, EditCarBrandValidator validator) : base(context, user)
        {
            _validator = validator;
        }
        public int Id => 28;

        public string Name => "Edit CarBrand";

        public string Description => "Edit CarBrand";

        public void Execute(CarBrandDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  CarBrands 
                    SET 
                    CarBrandName = @CarBrandName,
                    EditedAt = @EditedAt
                    WHERE Id = @Id";

                DynamicParameters param = new DynamicParameters();
                param.Add("@CarBrandName", request.CarBrandName);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }


}
