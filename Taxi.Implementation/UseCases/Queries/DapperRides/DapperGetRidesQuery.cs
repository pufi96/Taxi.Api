using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperRides
{
    public class DapperGetRidesQuery : DapperUseCase, IGetRidesQuery
    {
        public DapperGetRidesQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 19;

        public string Name => "Get Rides";

        public string Description => "Get Rides";

        public IEnumerable<RideDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM Rides";
            using (var connection = Context.CreateConnection())
            {
                var rides = connection.Query<RideDto>(query);
                return rides.AsList();
            }
        }
    }
}
