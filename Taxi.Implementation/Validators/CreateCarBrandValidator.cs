using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.Validators
{
    public class CreateCarBrandValidator : AbstractValidator<CreateCarBrandDto>
    {
        private TaxiDbContext _context;
        public CreateCarBrandValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.CarBrandName).NotEmpty().WithMessage("Car brand name is required.")
                                        .Must(CarBrandNotInUse).WithMessage("Car brand name is already in use.");
            _context = context;

        }

        private bool CarBrandNotInUse( string name)
        {
            var exists = _context.CarBrands.Any(x => x.CarBrandName == name);
            return exists;
        }
    }
}
