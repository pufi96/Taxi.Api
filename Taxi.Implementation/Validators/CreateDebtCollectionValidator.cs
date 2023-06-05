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
    public class CreateDebtCollectionValidator : AbstractValidator<CreateDebtCollectionDto>
    {
        private TaxiDbContext _context;
        public CreateDebtCollectionValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            _context = context;

            RuleFor(x => x.Debtor).NotEmpty().WithMessage("Debtor is required.")
                                     .Must(DebtorExsist).WithMessage("Debtor doesn't exsist.");

            RuleFor(x => x.DebtCollectionPrice).NotEmpty().WithMessage("Price ius required")
                                                .Must(PriceCheck).WithMessage("Price must be higher than 0.");
        }

        private bool DebtorExsist(DebtorDto debtor)
        {
            var exists = _context.Debtors.Any(x => x.Id == debtor.Id);
            return exists;
        }
        private bool PriceCheck(double price)
        {
            return price>0;
        }
    }
}
