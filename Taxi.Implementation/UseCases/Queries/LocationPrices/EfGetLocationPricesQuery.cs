using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.LocationPrice;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.LocationPrices
{
    public class EfGetLocationPricesQuery : EfUseCase, IGetLocationPricesQuery
    {
        public EfGetLocationPricesQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 13;

        public string Name => "Get LocationPrices";

        public string Description => "Get LocationPrices";

        public IEnumerable<LocationPricesDto> Execute(BaseSearch search)
        {
            var query = Context.LocationPrices
                                    .Include(x => x.LocationStart)
                                    .Include(x => x.LocationEnd)
                                    .AsQueryable();

            if (search.Keyword != null)
            {
                query = query.Where(x => x.LocationStart.LocationName == search.Keyword);
            }
            if (search.Keyword != null)
            {
                query = query.Where(x => x.LocationEnd.LocationName == search.Keyword);
            }

            IEnumerable<LocationPricesDto> result = Mapper.Map<IEnumerable<LocationPricesDto>>(query.ToList());

            return result;
        }
    }
}
