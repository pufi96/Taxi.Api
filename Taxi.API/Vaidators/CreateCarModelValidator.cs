using FluentValidation;
using System.Linq;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;

namespace Taxi.API.Vaidators
{
    public class CreateCarModelValidator : AbstractValidator<CreateCarModelDto>
    {
        public CreateCarModelValidator(TaxiDbContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.CarModelName)
                .NotEmpty()
                .WithMessage("Car model name must not be empty.")
                .Must(x => context.CarModels.Any(u => u.CarModelName == x))
                .WithMessage("Car model name already exist.");

            RuleFor(x => x.CarBrandId)
                .NotEmpty()
                .WithMessage("Car model must have car brand.");
        }
    }
}
