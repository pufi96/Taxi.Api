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
    public class DapperFindShiftRidesQuery : DapperUseCase, IFindShiftRidesQuery
    {
        public DapperFindShiftRidesQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 56;

        public string Name => "Find all Shift Rides";

        public string Description => "Find all Shift Rides";

        public IEnumerable<RideDto> Execute(int id)
        {
            var query = @"SELECT r.Id, lp.Id AS locationPriceId, r.IsLocal, r.RidePrice, r.ShiftId, ls.LocationName AS LocationStart, le.LocationName AS LocationEnd, r.DebtorId
                        FROM Rides AS r
                        LEFT JOIN LocationPrices AS lp ON r.LocationPriceId = lp.Id
                        LEFT JOIN Locations AS ls ON lp.LocationStartId = ls.Id
                        LEFT JOIN Locations AS le ON lp.LocationEndId = le.Id
                        WHERE ShiftId = @id";
            using (var connection = Context.CreateConnection())
            {
                var rides = connection.Query<RideDto>(query, new { id });
                return rides.AsList();
            }
        }
    }
}
