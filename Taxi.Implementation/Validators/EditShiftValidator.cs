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
    public class EditShiftValidator : AbstractValidator<ShiftDto>
    {
        private TaxiDbContext _context;
        public EditShiftValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop; 

            RuleFor(x => x.Id).NotEmpty().WithMessage("Shift id is required.")
                                       .Must(ShiftNotFound).WithMessage("Shift for edit is not found.");

            RuleFor(x => x.CarId).NotEmpty().WithMessage("Car is required.")
                                    .Must(CarDoesntExsist).WithMessage("Car doesn't exsist.");

            RuleFor(x => x.MileageStart).NotEmpty().WithMessage("Mileage start is required.")
                                        .Must(MileageStartWithHigherNumberThenCarMileage).WithMessage("Mileage must be positive number and can't be lower than car mileage.");

            _context = context;
        }
        private bool ShiftNotFound(int Id)
        {
            var exists = _context.Shifts.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }
        private bool CarDoesntExsist(int id)
        {
            var exists = _context.Cars.Any(x => x.Id == id);
            return exists;
        }
        private bool MileageStartWithHigherNumberThenCarMileage(int mileageStart)
        {
            var exists = _context.Shifts.Any(x => x.MileageStart >= _context.Cars.FirstOrDefault(y => y.Id == x.Id).Mileage);
            return exists;
        }
    }
}
