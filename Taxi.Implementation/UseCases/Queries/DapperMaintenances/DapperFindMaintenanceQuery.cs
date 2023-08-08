using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Maintenance;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperMaintenances
{
    public class DapperFindMaintenanceQuery : DapperUseCase, IFindMaintenanceQuery
    {
        public DapperFindMaintenanceQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 12;

        public string Name => "Find Maintenance";

        public string Description => "Find Maintenance";

        public MaintenanceDto Execute(int id)
        {
            var query = "SELECT * FROM Maintenances WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var maintenance = connection.QueryFirstOrDefault<MaintenanceDto>(query, new { id });
                return maintenance;
            }
        }
    }
}
