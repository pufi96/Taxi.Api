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
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.LocationPrices
{
    public class EfFindLocationPricesQuery : EfUseCase, IFindLocationPriceQuery
    {
        public EfFindLocationPricesQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Find LocationPrices";

        public string Description => "Find LocationPrices";

        public LocationPricesDto Execute(int id)
        {
            var query = Context.LocationPrices.Include(x => x.LocationStart)
                                    .Include(x => x.LocationEnd)
                                    .FirstOrDefault(x => x.Id == id & x.IsActive);

            LocationPricesDto result = Mapper.Map<LocationPricesDto>(query);

            return result;
        }

    }
}