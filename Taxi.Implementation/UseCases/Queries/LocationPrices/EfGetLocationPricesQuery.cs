using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.LocationPrice;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.LocationPrices
{
    public class EfGetLocationPricesQuery : EfUseCase, IGetLocationPriceQuery
    {
        public EfGetLocationPricesQuery(TaxiDbContext context) : base(context)
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

            IEnumerable<LocationPricesDto> result = Mapper.Map<IEnumerable<LocationPricesDto>>(query.ToList());

            return result;
        }
    }
}
