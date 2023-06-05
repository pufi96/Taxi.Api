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
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfCars
{
    public class EfDeleteCarCommand : EfUseCase, IDeleteCarCommand
    {
        public EfDeleteCarCommand(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 32;

        public string Name => "Delete Car";

        public string Description => "Delete Car";

        public void Execute(int id)
        {

            var car = Context.Cars.FirstOrDefault(x => x.Id == id && x.IsActive);

            if(car == null)
            {
                throw new EntityNotFoundException(nameof(Car), id);
            }
            car.IsActive = false;
            car.DeletedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
