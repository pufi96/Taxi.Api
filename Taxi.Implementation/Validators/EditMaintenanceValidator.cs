﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.Validators
{
    public class EditMaintenanceValidator : AbstractValidator<EditMaintenanceDto>
    {
        private TaxiDbContext _context;
        public EditMaintenanceValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            _context = context;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Maintenance id is required.")
                                       .Must(MaintenanceNotFound).WithMessage("Maintenance for edit is not found.");

            RuleFor(x => x.MaintenanceTypeId).NotEmpty().WithMessage("Maintenance type is required.")
                                        .Must(MaintenanceTypeNotExsist).WithMessage("Maintenance type doesn't exsist.");

            RuleFor(x => x.CarId).NotEmpty().WithMessage("Car is required.")
                                        .Must(CarNotFound).WithMessage("Car doesn't exsist.");

            RuleFor(x => x.Mileage).NotEmpty().WithMessage("Mileage is required.")
                                      .Must(PositiveNumber).WithMessage("Mileage must be positive number.");
        }

        private bool MaintenanceNotFound(int Id)
        {
            var exists = _context.Maintenances.Any(x => x.Id == Id);
            return exists;
        }
        private bool CarNotFound(int Id)
        {
            var exists = _context.Cars.Any(x => x.Id == Id);
            return exists;
        }
        private bool MaintenanceTypeNotExsist(int id)
        {
            var exists = _context.MaintenanceTypes.Any(x => x.Id == id);
            return exists;
        }
        private bool PositiveNumber(int positive)
        {
            return positive > 0;
        }
    }
}
