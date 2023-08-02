using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Location;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.Locations
{
    public class EfGetLocationsQuery : EfUseCase, IGetLocationsQuery
    {
        public EfGetLocationsQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 15;

        public string Name => "Get Location";

        public string Description => "Get Location";

        public IEnumerable<LocationDto> Execute(BaseSearch search)
        {
            var query = Context.Locations.AsQueryable();

            IEnumerable<LocationDto> result = Mapper.Map<IEnumerable<LocationDto>>(query.ToList());

            return result;
        }
    }
}
