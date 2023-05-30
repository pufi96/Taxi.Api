using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Location;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.Locations
{
    public class EfFindLocationQuery : EfUseCase, IFindLocationQuery
    {
        public EfFindLocationQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Find Location";

        public string Description => "Find Location";

        public LocationDto Execute(int id)
        {
            var query = Context.Locations.FirstOrDefault(x => x.Id == id & x.IsActive);

            LocationDto result = Mapper.Map<LocationDto>(query);

            return result;
        }
    }
}
