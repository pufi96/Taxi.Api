using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Commands.CarBrand;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfCarBrands
{
    public class EfEditCarBrandCommand : EfUseCase, IEditCarBrandCommand
    {
        private EditCarBrandValidator _validator;
        public EfEditCarBrandCommand(TaxiDbContext context, IApplicationUser user, EditCarBrandValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 28;

        public string Name => "Edit CarBrand";

        public string Description => "Edit CarBrand";

        public void Execute(CarBrandDto request)
        {
            _validator.ValidateAndThrow(request);

            request.EditedAt = DateTime.UtcNow;

            var carBrand = Context.CarBrands.FirstOrDefault(x => x.Id == request.Id);

            Mapper.Map(request, carBrand);

            Context.SaveChanges();
        }
    }
}
