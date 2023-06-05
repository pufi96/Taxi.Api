using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;

namespace Taxi.API.Vaidators
{
    public class CreateCarModelValidator : AbstractValidator<CreateCarModelDto>
    {
        private TaxiDbContext _context;
        public CreateCarModelValidator(TaxiDbContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.CarModelName).NotEmpty().WithMessage("Car model name is required.")
                                        .Must(x => context.CarModels.Any(u => u.CarModelName == x))
                                        .WithMessage("Car model name already exist.");

            RuleFor(x => x.CarBrand).NotEmpty().WithMessage("Car brand id is required.")
                                      .Must(CarBrandNotFound).WithMessage("Car brand is not found.");

            _context = context;
        }
        private bool CarModelNotFound(int Id)
        {
            var exists = _context.CarModels.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }

        private bool CarBrandNotFound(CarBrandDto carBrand)
        {
            var exists = _context.CarBrands.Any(x => x.Id == carBrand.Id);
            return exists;
        }
    }
}
