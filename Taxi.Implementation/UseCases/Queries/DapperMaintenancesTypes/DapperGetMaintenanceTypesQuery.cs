using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.MaintenacesType;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperMaintenancesTypes
{
    public class DapperGetMaintenanceTypesQuery : DapperUseCase, IGetMaintenanceTypesQuery
    {
        public DapperGetMaintenanceTypesQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 17;

        public string Name => "Get MaintenanceTypes";

        public string Description => "Get MaintenanceTypes";

        public IEnumerable<MaintenanceTypeDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM MaintenanceTypes";
            using (var connection = Context.CreateConnection())
            {
                var maintenanceTypes = connection.Query<MaintenanceTypeDto>(query);
                return maintenanceTypes.AsList();
            }
        }
    }
}
