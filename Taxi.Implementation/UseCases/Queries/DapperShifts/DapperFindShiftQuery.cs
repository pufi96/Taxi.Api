using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperShifts
{
    public class DapperFindShiftQuery : DapperUseCase, IFindShiftQuery
    {
        public DapperFindShiftQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 24;

        public string Name => "Find Shift";

        public string Description => "Find Shift";

        public ShiftDto Execute(int id)
        {
            var query = @"SELECT * 
                        FROM Shifts 
                        WHERE Id = @id
                        ORDER BY ShiftEnd DESC";
            using (var connection = Context.CreateConnection())
            {
                var shift = connection.QueryFirstOrDefault<ShiftDto>(query, new { id });
                return shift;

            }
        }
    }
}
