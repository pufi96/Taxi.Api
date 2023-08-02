using AutoMapper;
using FluentValidation;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Ride;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfRides
{
    public class EfCreateRideCommand : EfUseCase, ICreateRideCommand
    {
        private CreateRideValidator _validator;
        public EfCreateRideCommand(TaxiDbContext context, IApplicationUser user, CreateRideValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 44;

        public string Name => "Create Ride";

        public string Description => "Create Ride";

        public void Execute(CreateRideDto request)
        {
            _validator.ValidateAndThrow(request);

            Ride ride = Mapper.Map<Ride>(request);

            Context.Rides.Add(ride);

            Context.SaveChanges();
        }
    }
}
