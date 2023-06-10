using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries
{
    public class EfGetLogEntriesQuery : EfUseCase, IGetLogEntries
    {
        public EfGetLogEntriesQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 49;

        public string Name => "Get Log";

        public string Description => "Get Log";

        public IEnumerable<LogDto> Execute(LogSearch search)
        {
            var query = Context.LogEntries.ProjectTo<LogDto>();
            if (search.Keyword != null)
            {
                query = query.Where(x => x.UseCaseName.Contains(search.Keyword));
            }

            if (search.DateFrom != null)
            {
                query = query.Where(x => x.CreatedAt > search.DateFrom);
            }

            if (search.DateTo != null)
            {
                query = query.Where(x => x.CreatedAt < search.DateTo);
            }

            IEnumerable<LogDto> result = Mapper.Map<IEnumerable<LogDto>>(query.ToList());

            return result;
        }
    }
}
