using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.CarBrand;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfCarBrands
{
    public class EfCreateCarBrandCommand : EfUseCase, ICreateCarBrandCommand
    {
        private CreateCarBrandValidator _validator;

        public EfCreateCarBrandCommand(TaxiDbContext context, IApplicationUser user, CreateCarBrandValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 27;

        public string Name => "Create CarBrand";

        public string Description => "Create CarBrand";

        public void Execute(CreateCarBrandDto request)
        {
            _validator.ValidateAndThrow(request);

            CarBrand carBrand = Mapper.Map<CarBrand>(request);

            Context.CarBrands.Add(carBrand);
            Context.SaveChanges();
        }
    }
}
