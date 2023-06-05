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
    public class CreateDebtorValidator : AbstractValidator<CreateDebtorDto>
    {
        public CreateDebtorValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DebtorFirstName).NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.DebtorLastName).NotEmpty().WithMessage("Last name is required.");

        }
    }
}
