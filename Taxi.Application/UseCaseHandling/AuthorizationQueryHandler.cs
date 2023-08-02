using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases;
using Taxi.Domain;

namespace Taxi.Application.UseCaseHandling
{
    public class AuthorizationQueryHandler : IQueryHandler
    {
        private IApplicationUser _user;
        private IQueryHandler _next;

        public AuthorizationQueryHandler(IApplicationUser user, IQueryHandler next)
        {
            _user = user;
            if(next == null )
            {
                throw new ArgumentNullException("next");
            }
            _next = next;
        }

        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search) where TResult : class
        {
            if(!_user.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseExecutionException(_user.Username, query.Name);
            }

            return _next.HandleQuery(query, search);
        }
    }
}
