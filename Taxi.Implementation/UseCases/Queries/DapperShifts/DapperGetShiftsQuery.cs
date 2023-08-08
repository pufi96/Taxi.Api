using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.DapperShifts
{
    public class DapperGetShiftsQuery : DapperUseCase, IGetShiftsQuery
    {
        public DapperGetShiftsQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 23;

        public string Name => "Get Shifts";

        public string Description => "Get Shifts";

        public IEnumerable<ShiftDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM Shifts";
            using (var connection = Context.CreateConnection())
            {
                var shifts = connection.Query<ShiftDto>(query);
                return shifts.AsList();
            }
        }
    }
}
