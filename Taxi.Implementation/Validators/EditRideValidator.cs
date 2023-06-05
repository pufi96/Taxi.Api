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
    public class EditRideValidator : AbstractValidator<RideDto>
    {
        private TaxiDbContext _context;
        public EditRideValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Ride id is required.")
                                      .Must(RideNotFound).WithMessage("Ride for edit is not found.");

            RuleFor(x => x.RidePrice).NotEmpty().WithMessage("Price is required.")
                                    .Must(PositiveNumber).WithMessage("Price must be positive number.");

            RuleFor(x => x.LocationPriceId).Must(LocationPriceDoesntExsist)
                                            .When(x => x.IsLocal == false)
                                            .WithMessage("Location is required when it's not local ride.");
            _context = context;
        }
        private bool LocationPriceDoesntExsist(int id)
        {
            var exists = _context.LocationPrices.Any(x => x.Id == id);
            return exists;
        }
        private bool RideNotFound(int Id)
        {
            var exists = _context.Rides.Any(x => x.Id == Id);
            return exists;
        }
        private bool PositiveNumber(double positive)
        {
            return positive > 0;
        }
    }
}
