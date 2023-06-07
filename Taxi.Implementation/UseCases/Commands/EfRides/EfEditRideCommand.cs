using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Ride;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfRides
{
    public class EfEditRideCommand : EfUseCase, IEditRideCommand
    {
        private EditRideValidator _validator;
        public EfEditRideCommand(TaxiDbContext context, IApplicationUser user, EditRideValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 45;

        public string Name => "Edit Ride";

        public string Description => "Edit Ride";

        public void Execute(EditRideDto request)
        {
            _validator.ValidateAndThrow(request);

            request.EditedAt = DateTime.UtcNow;

            var ride = Context.Rides.FirstOrDefault(x => x.Id == request.Id);

            Mapper.Map(request, ride);

            Context.SaveChanges();
        }
    }
}
