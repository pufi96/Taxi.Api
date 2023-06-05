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
    public class EditDebtorValidator : AbstractValidator<DebtorDto>
    {
        private TaxiDbContext _context;
        public EditDebtorValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            _context = context;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Car id is required.")
                                       .Must(DebtorNotFound).WithMessage("Car for edit is not found.");

            RuleFor(x => x.DebtorFirstName).NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.DebtorLastName).NotEmpty().WithMessage("Last name is required.");
            
        }
        private bool DebtorNotFound(int Id)
        {
            var exists = _context.Debtors.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }
    }
}
