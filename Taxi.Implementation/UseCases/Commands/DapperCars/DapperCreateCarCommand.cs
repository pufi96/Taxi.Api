using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Car;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperCars
{
    public class DapperCreateCarCommand : DapperUseCase, ICreateCarCommand
    {
        private CreateCarValidator _validator;
        public DapperCreateCarCommand(DapperContext context, IApplicationUser user, CreateCarValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 31;

        public string Name => "Create Car";

        public string Description => "Create Car";

        public void Execute(CreateCarDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO Cars
                    (Registration, ValidityOfRegistration, Mileage, Description, Color, ChassisNumber, EngineVolume, HorsePower, ImageFilePath, FuelTypeId, CarModelId)
                    VALUES (@Registration, @ValidityOfRegistration, @Mileage, @Description, @Color, @ChassisNumber, @EngineVolume, @HorsePower, @ImageFilePath, @FuelTypeId, @CarModelId)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@Registration", request.Registration);
                param.Add("@ValidityOfRegistration", request.ValidityOfRegistration);
                param.Add("@Mileage", request.Mileage);
                param.Add("@Description", request.Description);
                param.Add("@Color", request.Color);
                param.Add("@ChassisNumber", request.ChassisNumber);
                param.Add("@EngineVolume", request.EngineVolume);
                param.Add("@HorsePower", request.HorsePower);
                param.Add("@ImageFilePath", request.ImageFilePath);
                param.Add("@FuelTypeId", request.FuelTypeId);
                param.Add("@CarModelId", request.CarModelId);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
