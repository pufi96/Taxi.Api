using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Commands.User;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfUsers
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        public EfDeleteUserCommand(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 47;

        public string Name => "Delete User";

        public string Description => "Delete User";

        public void Execute(int id)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == id && x.IsActive);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), id);
            }

            user.IsActive = false;
            user.DeletedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
