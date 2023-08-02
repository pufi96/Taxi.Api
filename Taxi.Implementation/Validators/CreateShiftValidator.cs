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
    public class CreateShiftValidator : AbstractValidator<CreateShiftDto>
    {
        private TaxiDbContext _context;
        public CreateShiftValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Car is required.")
                                    .Must(CarDoesntExsist).WithMessage("Car doesn't exsist.");

            RuleFor(x => x.MileageStart).NotEmpty().WithMessage("Mileage start is required.")
                                        .Must(MileageStartWithHigherNumberThenCarMileage).WithMessage("Mileage must be positive number and can't be lower than car mileage.");

            RuleFor(x => x.UserId).NotEmpty().WithMessage("User is required")
                                    .Must(IsShiftActive).WithMessage("Shift is already active.");
            _context = context;
        }
        private bool CarDoesntExsist(int car)
        {
            var exists = _context.Cars.Any(x => x.Id == car);
            return exists;
        }
        private bool MileageStartWithHigherNumberThenCarMileage(int mileageStart)
        {
            var exists = _context.Shifts.Any(x => mileageStart >= x.Car.Mileage);
            return exists;
        }
        private bool IsShiftActive(int user)
        {
            var active = _context.Shifts.Any(x => x.UserId == user && x.ShiftEnd == null);
            return !active;
        }
    }
}
