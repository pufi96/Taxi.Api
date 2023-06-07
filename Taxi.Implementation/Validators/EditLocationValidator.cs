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
    public class EditLocationValidator : AbstractValidator<LocationDto>
    {
        private TaxiDbContext _context;
        public EditLocationValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            _context = context;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Location id is required.")
                                      .Must(LocationNotFound).WithMessage("Location for edit is not found.");

            RuleFor(x => x.LocationName).NotEmpty().WithMessage("Location name is required.")
                                        .Must(LocationNotInUse).WithMessage("Location name is already in use.");

        } 
        private bool LocationNotFound(int Id)
        {
            var exists = _context.Locations.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }
        private bool LocationNotInUse(string name)
        {
            var exists = _context.Locations.Any(x => x.LocationName.ToLower() == name.ToLower());
            return !exists;
        }
    }
}
