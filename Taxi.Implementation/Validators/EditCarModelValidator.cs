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
    public class EditCarModelValidator : AbstractValidator<CarModelDto>
    {
        private TaxiDbContext _context;
        public EditCarModelValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Car model id is required.")
                                        .Must(CarModelNotFound).WithMessage("Car model for edit is not found.");

            RuleFor(x => x.CarModelName).NotEmpty().WithMessage("Car model name is required.");

            RuleFor(x => x.CarBrand).NotEmpty().WithMessage("Car brand id is required.")
                                      .Must(CarBrandNotFound).WithMessage("Car brand is not found.");
            _context = context;
        }
        private bool CarModelNotFound(int Id)
        {
            var exists = _context.CarModels.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }

        private bool CarBrandNotFound(CarBrandDto carBrand)
        {
            var exists = _context.CarBrands.Any(x => x.Id == carBrand.Id);
            return exists;
        }
    }
}
