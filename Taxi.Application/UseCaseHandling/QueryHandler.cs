using Taxi.Application.UseCases;

namespace Taxi.Application.UseCaseHandling
{
    public class QueryHandler : IQueryHandler
    {
        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search) 
            where TResult : class
        {
            return query.Execute(search);
        }
    }
}
