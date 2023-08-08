using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Location;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperLocations
{
    public class DapperFindLocationQuery : DapperUseCase, IFindLocationQuery
    {
        public DapperFindLocationQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 16;

        public string Name => "Find Location";

        public string Description => "Find Location";

        public LocationDto Execute(int id)
        {
            var query = "SELECT * FROM Locations WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var location = connection.QueryFirstOrDefault<LocationDto>(query, new { id });
                return location;
            }
        }
    }
}
