using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Car;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperCars
{
    public class DapperEditCarCommand : DapperUseCase, IEditCarCommand
    {
        private EditCarValidator _validator;
        public DapperEditCarCommand(DapperContext context, IApplicationUser user, EditCarValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 33;

        public string Name => "Edit Car";

        public string Description => "Edit Car";

        public void Execute(CarDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  Cars 
                    SET 
                    Registration = @Registration,
                    ValidityOfRegistration = @ValidityOfRegistration,
                    Mileage = @Mileage,
                    Description = @Description,
                    Color = @Color,
                    ChassisNumber = @ChassisNumber,
                    EngineVolume = @EngineVolume,
                    HorsePower = @HorsePower,
                    ImageFilePath = @ImageFilePath,
                    FuelTypeId = @FuelTypeId,
                    CarModelId = @CarModelId,
                    EditedAt = @EditedAt
                    WHERE Id = @Id"
                ;

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
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
