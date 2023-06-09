using FluentValidation;
using System.Linq;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserDto>
    {
        private TaxiDbContext _context;
        public EditUserValidator(TaxiDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            _context = context;

            RuleFor(x => x.Id).NotEmpty().WithMessage("User id is required.")
                                       .Must(UsertNotFound).WithMessage("User for edit is not found.");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.Earnings).NotEmpty().WithMessage("Earnings are required in %.")
                                     .Must(PositiveNumber).WithMessage("Earnings must be positive number.");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.")
                                     .Must(UsernameIsAlreadyInUse).WithMessage("Username is already in use.");
        }
        private bool UsertNotFound(int Id)
        {
            var exists = _context.Users.Any(x => x.Id == Id && x.IsActive);
            return exists;
        }
        private bool PositiveNumber(double positive)
        {
            return positive > 0;
        }
        private bool UsernameIsAlreadyInUse(string username)
        {
            var exists = _context.Users.Any(x => x.Username == username);
            return !exists;
        }
    }
}
