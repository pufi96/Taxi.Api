using FluentValidation;
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
    public class CreateRideValidator : AbstractValidator<CreateRideDto>
    {
        private TaxiDbContext _context;
        public CreateRideValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.RidePrice).NotEmpty().WithMessage("Price is required.")
                                    .Must(PositiveNumber).WithMessage("Price must be positive number.");

            RuleFor(x => x.LocationPrice).Must(LocationPriceDoesntExsist)
                                            .When(x => x.IsLocal == false)
                                            .WithMessage("Location is required when it's not local ride.");

            RuleFor(x => x.Shift).Must(ShiftDoesntExsistOrIsntActive).WithMessage("That shift doesn't exsist or isn't active.");

            _context = context;
        }
        private bool LocationPriceDoesntExsist(LocationPricesDto locationPrice)
        {
            var exists = _context.LocationPrices.Any(x => x.Id == locationPrice.Id);
            return exists;
        }
        private bool ShiftDoesntExsistOrIsntActive(ShiftDto shift)
        {
            var exists = _context.Shifts.Any(x => x.Id == shift.Id && x.ShiftEnd != null);
            return exists;
        }
        private bool PositiveNumber(double positive)
        {
            return positive > 0;
        }
    }
}
