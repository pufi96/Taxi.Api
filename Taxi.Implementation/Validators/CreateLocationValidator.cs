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
    public class CreateLocationValidator : AbstractValidator<CreateLocationDto>
    {
        private TaxiDbContext _context;
        public CreateLocationValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.LocationName).NotEmpty().WithMessage("Location name is required.")
                                        .Must(LocationNotInUse).WithMessage("Location name is already in use.");
            _context = context;

        }

        private bool LocationNotInUse(string name)
        {
            var exists = _context.Locations.Any(x => x.LocationName == name);
            return exists;
        }
    }
}
