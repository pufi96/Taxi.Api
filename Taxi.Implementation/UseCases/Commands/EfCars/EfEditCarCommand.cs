using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Commands.Car;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfCars
{
    public class EfEditCarCommand : EfUseCase, IEditCarCommand
    {
        private EditCarValidator _validator;
        public EfEditCarCommand(TaxiDbContext context, IApplicationUser user, EditCarValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 33;

        public string Name => "Edit Car";

        public string Description => "Edit Car";

        public void Execute(EditCarDto request)
        {
            //{
            //    "registration": "BC 0003 BC",
            //    "validityOfRegistration": "2023-06-05T18:08:18.6946595",
            //    "mileage": 20000,
            //    "description": "Kao nov",
            //    "color": "Green",
            //    "chassisNumber": "12345678901234567",
            //    "engineVolume": 2200,
            //    "horsePower": 180,
            //    "imageFilePath": "img1.png",
            //    "fuelTypeId" : 1,
            //    "carModelId" : 2
            //}
            _validator.ValidateAndThrow(request);

            request.EditedAt = DateTime.UtcNow;

            var car = Context.Cars.FirstOrDefault(x => x.Id == request.Id);

            Mapper.Map(request, car);

            Context.SaveChanges();
        }
    }
}
