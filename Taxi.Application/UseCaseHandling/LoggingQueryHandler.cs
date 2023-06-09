using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.Logging;
using Taxi.Application.UseCases;

namespace Taxi.Application.UseCaseHandling
{
    public class LoggingQueryHandler : IQueryHandler
    {
        private IQueryHandler _next;
        private IApplicationUser _user;
        private IUseCaseLogger _logger;

        public LoggingQueryHandler(IQueryHandler next, IApplicationUser actor, IUseCaseLogger logger)
        {
            _next = next;
            if (next == null)
            {
                throw new ArgumentException();
            }
            _user = actor;
            _logger = logger;
        }

        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search) where TResult : class
        {
            _logger.Add(new UseCaseLogEntry
            {
                User = _user.Username,
                UserId = _user.Id,
                Data = search,
                UseCaseName = query.Name
            });

            return _next.HandleQuery(query, search);
        }
    }
}
