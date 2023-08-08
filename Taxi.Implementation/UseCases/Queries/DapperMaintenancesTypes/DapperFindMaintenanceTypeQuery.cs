using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.MaintenanceType;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperMaintenancesTypes
{
    public class DapperFindMaintenanceTypeQuery : DapperUseCase, IFindMaintenanceTypeQuery
    {
        public DapperFindMaintenanceTypeQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 18;

        public string Name => "Find MaintenanceType";

        public string Description => "Find MaintenanceType";

        public MaintenanceTypeDto Execute(int id)
        {
            var query = "SELECT * FROM MaintenanceTypes WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var maintenanceType = connection.QueryFirstOrDefault<MaintenanceTypeDto>(query, new { id });
                return maintenanceType;
            }
        }
    }
}
