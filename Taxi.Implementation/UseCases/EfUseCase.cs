using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected TaxiDbContext Context { get; }

        protected EfUseCase(TaxiDbContext context)
        {
            Context = context;
        }
    }
}
