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

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            request.EditedAt = DateTime.UtcNow;

            var user = Context.Users.FirstOrDefault(x => x.Id == request.Id);

            Mapper.Map(request, user);

            Context.SaveChanges();
        }
    }
}
