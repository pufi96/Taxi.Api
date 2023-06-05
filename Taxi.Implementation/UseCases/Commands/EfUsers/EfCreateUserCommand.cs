using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
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
        public EfCreateUserCommand(TaxiDbContext context, IApplicationUser user, CreateUserValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 46;

        public string Name => "Create User";

        public string Description => "Create User";

        public void Execute(CreateUserDto request)
        {
            _validator.ValidateAndThrow(request);

            var userActive = Context.Users.FirstOrDefault(x => x.Username == request.Username && !x.IsActive);

            request.UserRoleId = Context.Roles.FirstOrDefault(x => x.RoleName == "Driver").Id;

            if (userActive != null)
            {
                userActive.IsActive = true;
            }
            else
            {
                User user = Mapper.Map<User>(request);
                Context.Users.Add(user);
            }

            Context.SaveChanges();
        }
    }
}
