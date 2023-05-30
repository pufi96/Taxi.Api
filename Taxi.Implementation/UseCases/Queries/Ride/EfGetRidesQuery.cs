using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.MaintenacesType;
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.Ride
{
    public class EfGetRidesQuery : EfUseCase, IGetRideQuery
    {
        public EfGetRidesQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "Get Rides";

        public string Description => "Get Rides";

        public IEnumerable<RideDto> Execute(BaseSearch search)
        {
            var query = Context.Rides.Include(x => x.LocationPrice)
                                    .Include(x => x.InDebteds).ThenInclude(x => x.Debtor)
                                    .AsQueryable();

            IEnumerable<RideDto> result = Mapper.Map<IEnumerable<RideDto>>(query.ToList());

            return result;
        }
    }
}
