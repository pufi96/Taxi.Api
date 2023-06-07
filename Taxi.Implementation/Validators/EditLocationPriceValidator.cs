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
    public class EditLocationPriceValidator : AbstractValidator<EditLocationPricesDto>
    {
        private TaxiDbContext _context;
        public EditLocationPriceValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            _context = context;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Location price id is required.")
                                      .Must(LocationPriceNotFound).WithMessage("Location price for edit is not found.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.")
                                        .Must(PositiveNumber).WithMessage("Price must be positive number.");

            RuleFor(x => x.LocationStartId).NotEmpty().WithMessage("Start location is required.")
                                            .NotEqual(x => x.LocationEndId).WithMessage("Start location and end location can't be the same.")
                                            .Must(LocationNotExsist).WithMessage("Start location doesn't exsist.");

            RuleFor(x => x.LocationEndId).NotEmpty().WithMessage("End location is required.")
                                            .NotEqual(x => x.LocationStartId).WithMessage("Start location and end location can't be the same.")
                                            .Must(LocationNotExsist).WithMessage("End location doesn't exsist.");

            RuleFor(x => x).Must(BeUniqueFirst).WithMessage("Combination location already exsist.")
                           .Must(BeUniqueSecound).WithMessage("Combination location already exsist.");
        }
        private bool BeUniqueFirst(EditLocationPricesDto model)
        {
            var first = _context.LocationPrices.Any(x => x.LocationEndId == model.LocationEndId && x.LocationStartId == model.LocationStartId);
            return !first;
        }
        private bool BeUniqueSecound(EditLocationPricesDto model)
        {
            var secound = _context.LocationPrices.Any(x => x.LocationEndId == model.LocationStartId && x.LocationStartId == model.LocationEndId);
            return !secound;
        }
        private bool LocationPriceNotFound(int Id)
        {
            var exists = _context.LocationPrices.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }
        private bool LocationNotExsist(int locationId)
        {
            var exists = _context.Locations.Any(x => x.Id == locationId && x.IsActive);
            return exists;
        }
        private bool PositiveNumber(double positive)
        {
            return positive > 0;
        }
    }
}
