using Dapper;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperShifts
{
    public class DapperFindUnfinishedShiftQuery : DapperUseCase, IFindUnfinishedShiftQuery
    {
        public DapperFindUnfinishedShiftQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 50;

        public string Name => "Find unfinished shift";

        public string Description => "Find unfinished shift";

        public ShiftDto Execute(int id)
        {
            var query = @"SELECT s.* 
                        FROM Shifts AS s 
                        LEFT JOIN Users AS u ON s.UserId = u.Id 
                        WHERE s.UserId = @id AND s.ShiftEnd IS NULL";
            using (var connection = Context.CreateConnection())
            {
                var shift = connection.QueryFirstOrDefault<ShiftDto>(query, new { id });

                return shift;
            }
        }
    }
}
