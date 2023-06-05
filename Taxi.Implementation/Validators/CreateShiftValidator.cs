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

            _context = context;
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
