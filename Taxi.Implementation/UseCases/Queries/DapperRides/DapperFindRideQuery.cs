using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperRides
{
    public class DapperFindRideQuery : DapperUseCase, IFindRideQuery
    {
        public DapperFindRideQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 20;

        public string Name => "Find Ride";

        public string Description => "Find Ride";

        public RideDto Execute(int id)
        {
            var query = "SELECT * FROM Rides WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var ride = connection.QueryFirstOrDefault<RideDto>(query, new { id });
                return ride;

            }
        }
    }
}
