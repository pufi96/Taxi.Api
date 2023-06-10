using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Email;
using Taxi.Application.UseCases.Commands.User;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfUsers
{
    public class EfCreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private CreateUserValidator _validator;
        private IEmailSender _sender;
        public EfCreateUserCommand(TaxiDbContext context, IApplicationUser user, CreateUserValidator validator, IEmailSender sender) : base(context, user)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id => 46;

        public string Name => "Create User";

        public string Description => "Create User";

        public void Execute(CreateUserDto request)
        {
            _validator.ValidateAndThrow(request);

            var userActive = Context.Users.FirstOrDefault(x => x.Username == request.Username && !x.IsActive);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword("Admin12345.");
            request.Password = passwordHash;
            if (userActive != null)
            {
                userActive.IsActive = true;
            }
            else
            {
                request.UserRoleId = Context.Roles.FirstOrDefault(x => x.RoleName == "Driver").Id;

                User user = Mapper.Map<User>(request);
                Context.Users.Add(user);
            }


            Context.SaveChanges();
            _sender.SendEmail(new MailDto
            {
                To = userActive.Email,
                Subject = "Welcome to firm!",
                Body = $"Your initial password is Admin1235. you can change it after login."
            });
        }
    }
}
