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
    public class EditCarValidator : AbstractValidator<CarDto>
    {
        private TaxiDbContext _context;
        public EditCarValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Car id is required.")
                                       .Must(CarNotFound).WithMessage("Car for edit is not found.");

            RuleFor(x => x.Mileage).NotEmpty().WithMessage("Mileage is required.")
                                    .Must(PositiveNumber).WithMessage("Mileage must be positive number.");

            RuleFor(x => x.HorsePower).NotEmpty().WithMessage("Horse power is required.")
                                    .Must(PositiveNumber).WithMessage("Horse power must be positive number.");

            RuleFor(x => x.EngineVolume).NotEmpty().WithMessage("Engine volume is required.")
                                    .Must(EngiveVolume).WithMessage("Engine volume must be higher than 600.");

            RuleFor(x => x.ChassisNumber).NotEmpty().WithMessage("Chassis number is required.")
                                    .Must(ChassisNumber).WithMessage("Chassis number must have 17 characters.");

            RuleFor(x => x.FuelTypeId).NotEmpty().WithMessage("Fuel type is required.")
                                    .Must(FuelTypeDoesntExsist).WithMessage("Fuel type doesn't exsist.");

            RuleFor(x => x.CarModelId).NotEmpty().WithMessage("Car model is required.")
                                    .Must(CarModelDoesntExsist).WithMessage("Car model doesn't exsist.");

            _context = context;
        }
        private bool CarNotFound(int Id)
        {
            var exists = _context.Cars.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }
        private bool CarModelDoesntExsist(int carModelId)
        {
            var exists = _context.CarModels.Any(x => x.Id == carModelId);
            return exists;
        }
        private bool FuelTypeDoesntExsist(int fuelTypeId)
        {
            var exists = _context.FuelTypes.Any(x => x.Id == fuelTypeId);
            return exists;
        }
        private bool PositiveNumber(int positive)
        {
            return positive > 0;
        }
        private bool EngiveVolume(double volume)
        {
            return volume > 600;
        }
        private bool ChassisNumber(string chassisNumber)
        {
            return chassisNumber.Length == 17;
        }
    }
}
