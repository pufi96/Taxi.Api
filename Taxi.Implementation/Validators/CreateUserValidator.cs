using FluentValidation;
using System.Linq;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        private TaxiDbContext _context;
        public CreateUserValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            _context = context;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.Earnings).NotEmpty().WithMessage("Earnings are required in %.")
                                     .Must(PositiveNumber).WithMessage("Earnings must be positive number.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.")
                                     .Must(UsernameIsAlreadyInUse).WithMessage("Username is already in use.");
        }
        private bool PositiveNumber(double positive)
        {
            return positive > 0;
        }
        private bool UsernameIsAlreadyInUse(string username)
        {
            if(string.IsNullOrEmpty(username)) return true;

            var exists = _context.Users.Any(x => x.Username == username);
            return !exists;
        }
    }
}
