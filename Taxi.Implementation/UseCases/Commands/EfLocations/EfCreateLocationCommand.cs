using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Location;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfLocations
{
    public class EfCreateLocationCommand : EfUseCase, ICreateLocationCommand
    {
        private CreateLocationValidator _validator;
        public EfCreateLocationCommand(TaxiDbContext context, IApplicationUser user, CreateLocationValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 40;

        public string Name => "Create Location";

        public string Description => "Create Location";

        public void Execute(CreateLocationDto request)
        {
            _validator.ValidateAndThrow(request);

            Location location = Mapper.Map<Location>(request);

            Context.Locations.Add(location);
            Context.SaveChanges();
        }
    }
}
