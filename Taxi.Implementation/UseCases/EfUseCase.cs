using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected TaxiDbContext Context { get; }

        protected IApplicationUser _user;

        protected EfUseCase(TaxiDbContext context, IApplicationUser user)
        {
            Context = context;
            _user = user;
        }
    }
}
