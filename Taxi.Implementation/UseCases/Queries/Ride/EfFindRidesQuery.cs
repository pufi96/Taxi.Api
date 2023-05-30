using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.Ride
{
    public class EfFindRidesQuery : EfUseCase, IFindRideQuery
    {
        public EfFindRidesQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Find Rides";

        public string Description => "Find Rides";

        public RideDto Execute(int id)
        {
            var query = Context.Rides.FirstOrDefault(x => x.Id == id & x.IsActive);

            RideDto result = Mapper.Map<RideDto>(query);

            return result;
        }
    }
}
