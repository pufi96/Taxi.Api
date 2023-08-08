using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Location;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperLocations
{
    public class DapperGetLocationsQuery : DapperUseCase, IGetLocationsQuery
    {
        public DapperGetLocationsQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }
        public int Id => 15;

        public string Name => "Get Locations";

        public string Description => "Get Locations";

        public IEnumerable<LocationDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM Locations";
            using (var connection = Context.CreateConnection())
            {
                var locations = connection.Query<LocationDto>(query);
                return locations.AsList();
            }
        }
    }
}
