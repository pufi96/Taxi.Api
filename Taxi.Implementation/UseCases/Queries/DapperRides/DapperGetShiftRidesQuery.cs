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
    public class DapperGetShiftRidesQuery : DapperUseCase, IGetShiftRidesQuery
    {
        public DapperGetShiftRidesQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 56;

        public string Name => "Get all Shift Rides";

        public string Description => "Get all Shift Rides";

        public IEnumerable<RideDto> Execute(int id)
        {
            var query = @"SELECT * FROM Rides 
                        WHERE ShiftId = @id";
            using (var connection = Context.CreateConnection())
            {
                var rides = connection.Query<RideDto>(query, new { id });
                return rides.AsList();
            }
        }
    }
}
