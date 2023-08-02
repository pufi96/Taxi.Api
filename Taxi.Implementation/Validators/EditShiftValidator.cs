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
    public class EditShiftValidator : AbstractValidator<UpdateShiftDto>
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
                                        .Must(MileageStartWithHigherNumberThenCarMileage).WithMessage("Mileage start must be positive number and can't be lower than car mileage.");
           
            RuleFor(x => x.MileageEnd).NotEmpty().WithMessage("Mileage start is required.")
                                        .Must(MileageEndWithHigherNumberThenMileageStart).WithMessage("Mileage end can't be lower than mileage start.");

            _context = context;
        }
        private bool ShiftNotFound(int Id)
        {
            var exists = _context.Shifts.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }
        private bool CarDoesntExsist(int Id)
        {
            var exists = _context.Cars.Any(x => x.Id == Id);
            return exists;
        }
        private bool MileageStartWithHigherNumberThenCarMileage(int mileageStart)
        {
            var exists = _context.Shifts.Any(x => mileageStart >= x.Car.Mileage);
            return exists;
        }
        private bool MileageEndWithHigherNumberThenMileageStart(int? mileageEnd)
        {
            var exists = _context.Shifts.Any(x => mileageEnd >= x.MileageStart);
            return exists;
        }
    }
}
