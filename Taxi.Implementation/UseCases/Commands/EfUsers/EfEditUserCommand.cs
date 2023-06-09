using AutoMapper;
using FluentValidation;
using System;
using System.Linq;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.User;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfUsers
{
    public class EfEditUserCommand : EfUseCase, IEditUserCommand
    {
        private EditUserValidator _validator;
        public EfEditUserCommand(TaxiDbContext context, IApplicationUser user, EditUserValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 48;

        public string Name => "Edit User";

        public string Description => "Edit User";

        public void Execute(EditUserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = Context.Users.FirstOrDefault(x => x.Id == request.Id);
           
            if(_user.Id == request.Id)
            {
                request.UserRoleId = Context.Roles.FirstOrDefault(x => x.RoleName == "Driver").Id;
                request.Earnings = (double)user.Earnings;
                request.Username = user.Username;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }

            request.EditedAt = DateTime.UtcNow;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            request.Password = passwordHash;

            Mapper.Map(request, user);

            Context.SaveChanges();
        }
    }
}
