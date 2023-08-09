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
    public class DapperGetUserShiftsQuery : DapperUseCase, IGetUserShifts
    {
        public DapperGetUserShiftsQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 53;

        public string Name => "Get all User Shifts";

        public string Description => "Get all User Shifts";

        public IEnumerable<ShiftDto> Execute(int id)
        {
            var query = @"SELECT * FROM Shifts 
                        WHERE UserId = @id
                        ORDER BY ShiftEnd DESC";
            using (var connection = Context.CreateConnection())
            {
                var shifts = connection.Query<ShiftDto>(query, new {id});
                return shifts.AsList();
            }
        }
    }
}
