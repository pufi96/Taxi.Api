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
    public class EditLocationPriceValidator : AbstractValidator<LocationPricesDto>
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

            RuleFor(x => x.LocationStart).NotEmpty().WithMessage("Start location is required.")
                                      .Must(LocationNotExsist).WithMessage("Start location doesn't exsist.");

            RuleFor(x => x.LocationEnd).NotEmpty().WithMessage("End location is required.")
                                      .Must(LocationNotExsist).WithMessage("End location doesn't exsist.");
        }
        private bool LocationPriceNotFound(int Id)
        {
            var exists = _context.LocationPrices.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }
        private bool LocationNotExsist(string locationName)
        {
            var exists = _context.Locations.Any(x => x.LocationName == locationName && x.IsActive);
            return exists;
        }
        private bool PositiveNumber(double positive)
        {
            return positive > 0;
        }
    }
}
