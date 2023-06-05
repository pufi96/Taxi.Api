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
    public class CreateMaintenanceValidator : AbstractValidator<CreateMaintenanceDto>
    {
        private TaxiDbContext _context;
        public CreateMaintenanceValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            _context = context;

            RuleFor(x => x.MaintenanceType).NotEmpty().WithMessage("Maintenance type is required.")
                                        .Must(MaintenanceTypeNotExsist).WithMessage("Maintenance type doesn't exsist.");


            RuleFor(x => x.Mileage).NotEmpty().WithMessage("Mileage is required.")
                                      .Must(PositiveNumber).WithMessage("Mileage must be positive number.");
        }

        private bool MaintenanceTypeNotExsist(MaintenanceTypeDto maintenanceType)
        {
            var exists = _context.MaintenanceTypes.Any(x => x.Id == maintenanceType.Id);
            return exists;
        }
        private bool PositiveNumber(int positive)
        {
            return positive > 0;
        }
    }
}
