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
    public class CreateLocationPriceValidator : AbstractValidator<CreateLocationPricesDto>
    {
        private TaxiDbContext _context;
        public CreateLocationPriceValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            _context = context;

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
        private bool BeUniqueFirst(CreateLocationPricesDto model)
        {
            var first = _context.LocationPrices.Any(x => x.LocationEndId == model.LocationEndId && x.LocationStartId == model.LocationStartId);
            return !first;
        }
        private bool BeUniqueSecound(CreateLocationPricesDto model)
        {
            var secound = _context.LocationPrices.Any(x => x.LocationEndId == model.LocationStartId && x.LocationStartId == model.LocationEndId);
            return !secound;
        }
        private bool LocationNotExsist(int id)
        {
            var exists = _context.Locations.Any(x => x.Id == id && x.IsActive);
            return exists;
        }
        private bool PositiveNumber(double positive)
        {
            return positive > 0;
        }
    }
}
