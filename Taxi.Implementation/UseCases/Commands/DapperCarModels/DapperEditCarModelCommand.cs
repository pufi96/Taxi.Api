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
    public class DapperEditCarModelCommand : DapperUseCase, IEditCarModelCommand
    {
        private EditCarModelValidator _validator;
        public DapperEditCarModelCommand(DapperContext context, IApplicationUser user, EditCarModelValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Edit CarModel";

        public string Description => "Edit CarModel";

        public void Execute(CarModelDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  CarBrands 
                    SET 
                    CarModelName = @CarModelName,
                    CarBrandId = @CarBrandId,
                    EditedAt = @EditedAt
                    WHERE Id = @Id";

                DynamicParameters param = new DynamicParameters();
                param.Add("@CarModelName", request.CarModelName);
                param.Add("@CarBrandId", request.CarBrandId);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
