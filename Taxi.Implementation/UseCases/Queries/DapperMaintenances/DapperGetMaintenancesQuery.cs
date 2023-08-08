using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Maintenance;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperMaintenances
{
    public class DapperGetMaintenancesQuery : DapperUseCase, IGetMaintenancesQuery
    {
        public DapperGetMaintenancesQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 11;

        public string Name => "Get Maintenance";

        public string Description => "Get Maintenance";

        public IEnumerable<MaintenanceDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM Maintenances";
            using (var connection = Context.CreateConnection())
            {
                var maintenances = connection.Query<MaintenanceDto>(query);
                return maintenances.AsList();
            }
        }
    }
}
