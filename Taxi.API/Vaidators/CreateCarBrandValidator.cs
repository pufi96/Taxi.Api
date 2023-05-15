using FluentValidation;
using System.Linq;
using Taxi.API.DTO;
using Taxi.DatabaseAccess;

namespace Taxi.API.Vaidators
{
    public class CreateCarBrandValidator : AbstractValidator<CarBrandDto>
    {
        public CreateCarBrandValidator(TaxiContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.CarBrandName)
                .NotEmpty()
                .WithMessage("Car brand name must not be empty.")
                .Must(x => context.CarBrands.Any(u => u.CarBrandName == x))
                .WithMessage("Car brand name already exist.");
        }
    }
}
