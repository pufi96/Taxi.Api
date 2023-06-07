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
    public class EditCarBrandValidator : AbstractValidator<CarBrandDto>
    {
        private TaxiDbContext _context;
        public EditCarBrandValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Car brand id is required.")
                                        .Must(CarBrandNotFound).WithMessage("Car brand for edit is not found.");

            RuleFor(x => x.CarBrandName).NotEmpty().WithMessage("Car brand name is required.")
                                        .Must(CarBrandNotInUse).WithMessage("Car brand name is already in use.");


            _context = context;
        }
        private bool CarBrandNotFound(int Id)
        {
            var exists = _context.CarBrands.Any(x => x.Id == Id);
            return exists;
        }
        private bool CarBrandNotInUse(string name)
        {
            var exists = _context.CarBrands.Any(x => x.CarBrandName == name && x.IsActive);
            return !exists;
        }
    }
}
