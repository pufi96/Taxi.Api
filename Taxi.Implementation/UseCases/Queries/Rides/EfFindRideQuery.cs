using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.Rides
{
    public class EfFindRideQuery : EfUseCase, IFindRideQuery
    {

        public EfFindRideQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 20;

        public string Name => "Find Rides";

        public string Description => "Find Rides";

        public RideDto Execute(int id)
        {
            var query = Context.Rides.FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Ride), id);
            }

            RideDto result = Mapper.Map<RideDto>(query);

            return result;
        }
    }
}
