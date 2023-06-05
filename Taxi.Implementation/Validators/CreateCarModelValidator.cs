﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.Validators
{
    public class CreateCarModelValidator : AbstractValidator<CreateCarModelDto>
    {
        private TaxiDbContext _context;
        public CreateCarModelValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            
            _context = context;

            RuleFor(x => x.CarModelName).NotEmpty().WithMessage("Car model name is required.")
                                        .Must(CarModelNotInUse).WithMessage("Car model name is already in use.");


            RuleFor(x => x.CarBrand).NotEmpty().WithMessage("Car model name is required.")
                                      .Must(CarBrandNotExsist).WithMessage("Car brand doesn't exsist.");
        }

        private bool CarModelNotInUse(string name)
        {
            var exists = _context.CarModels.Any(x => x.CarModelName == name);
            return exists;
        }
        private bool CarBrandNotExsist(CarBrandDto carBrand)
        {
            var exists = _context.CarBrands.Any(x => x.Id == carBrand.Id);
            return exists;
        }
    }
}
