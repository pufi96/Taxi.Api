using AutoMapper;
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
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfCars
{
    public class EfCreateCarCommand : EfUseCase, ICreateCarCommand
    {
        private CreateCarValidator _validator;
        public EfCreateCarCommand(TaxiDbContext context, IApplicationUser user, CreateCarValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 31;

        public string Name => "Create Car";

        public string Description => "Create Car";

        public void Execute(CreateCarDto request)
        {
            _validator.ValidateAndThrow(request);

            var carActive = Context.Cars.FirstOrDefault(x => x.ChassisNumber == request.ChassisNumber && !x.IsActive);

            if (carActive != null)
            {
                carActive.IsActive = true;
            }
            else
            {
                var car = Mapper.Map<Car>(request);

                Context.Cars.Add(car);
            }
            Context.SaveChanges();
        }
    }
}
