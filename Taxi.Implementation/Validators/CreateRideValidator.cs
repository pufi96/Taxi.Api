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

            RuleFor(x => x.LocationPriceId).Must(LocationPriceDoesntExsist)
                                            .When(x => x.IsLocal == false)
                                            .WithMessage("Location is required when it's not local ride.");

            RuleFor(x => x.ShiftId).Must(ShiftDoesntExsistOrIsntActive).WithMessage("That shift doesn't exsist or isn't active.");

            _context = context;
        }
        private bool LocationPriceDoesntExsist(int id)
        {
            var exists = _context.LocationPrices.Any(x => x.Id == id);
            return exists;
        }
        private bool ShiftDoesntExsistOrIsntActive(int id)
        {
            var exists = _context.Shifts.Any(x => x.Id == id && x.ShiftEnd != null);
            return exists;
        }
        private bool PositiveNumber(double positive)
        {
            return positive > 0;
        }
    }
}
