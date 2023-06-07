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

            RuleFor(x => x.LocationPriceId).NotNull().WithMessage("LocationPriceId is required.")
                                            .Must(LocationPriceDoesntExsist)
                                            .When(x => !x.IsLocal)
                                            .WithMessage("Location is required when it's not local ride.");

            RuleFor(x => x.ShiftId).Must(ShiftDoesntExsistOrIsntActive).WithMessage("That shift doesn't exsist or isn't active.");

            RuleFor(x => x.DebtorId).GreaterThan(0).When(x => x.DebtorId.HasValue);

            _context = context;
        }
        private bool LocationPriceDoesntExsist(int? locationPriceId)
        {
            if(locationPriceId.HasValue) 
            {

                var exists = _context.LocationPrices.Any(x => x.Id == locationPriceId);
                return exists;
            }
            return true;
        }
        private bool ShiftDoesntExsistOrIsntActive(int shiftId)
        {
            var exists = _context.Shifts.Any(x => x.Id == shiftId && x.ShiftEnd != null);
            return exists;
        }
        private bool PositiveNumber(double positive)
        {
            return positive > 0;
        }
    }
}
