using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.LocationPrice;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfLocationPrices
{
    public class EfCreateLocationPriceCommand : EfUseCase, ICreateLocationPriceCommand
    {
        private CreateLocationPriceValidator _validator;
        public EfCreateLocationPriceCommand(TaxiDbContext context, IApplicationUser user, CreateLocationPriceValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 38;

        public string Name => "Create LocationPrice";

        public string Description => "Create LocationPrice";

        public void Execute(CreateLocationPricesDto request)
        {
            _validator.ValidateAndThrow(request);

            LocationPrice locationPrice = Mapper.Map<LocationPrice>(request);

            Context.LocationPrices.Add(locationPrice);
            Context.SaveChanges();
        }
    }
}
