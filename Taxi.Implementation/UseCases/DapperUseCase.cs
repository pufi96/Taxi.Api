using Taxi.Application;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases
{
    public abstract class DapperUseCase
    {
        protected DapperContext Context { get; }
        protected IApplicationUser _user;

        protected DapperUseCase(DapperContext context, IApplicationUser user)
        {
            Context = context;
            _user = user;
        }
    }
}
