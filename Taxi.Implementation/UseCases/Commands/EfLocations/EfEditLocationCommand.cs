using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Commands.Location;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfLocations
{
    public class EfEditLocationCommand : EfUseCase, IEditLocationCommand
    {
        private EditLocationValidator _validator;
        public EfEditLocationCommand(TaxiDbContext context, IApplicationUser user, EditLocationValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 41;

        public string Name => "Edit Location";

        public string Description => "Edit Location";

        public void Execute(LocationDto request)
        {
            _validator.ValidateAndThrow(request);

            request.EditedAt = DateTime.UtcNow;

            var locationPrice = Context.LocationPrices.FirstOrDefault(x => x.Id == request.Id);

            Mapper.Map(request, locationPrice);

            Context.SaveChanges();
        }
    }
}
