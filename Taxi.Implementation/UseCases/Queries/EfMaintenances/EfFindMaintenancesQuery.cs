using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Maintenance;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.EfMaintenances
{
    public class EfFindMaintenancesQuery : EfUseCase, IFindMaintenancesQuery
    {
        public EfFindMaintenancesQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Find Maintenance";

        public string Description => "Find Maintenance";

        public MaintenanceDto Execute(int id)
        {
            var query = Context.Maintenances.Include(x => x.MaintenaceType)
                                    .FirstOrDefault(x => x.Id == id & x.IsActive);

            MaintenanceDto result = Mapper.Map<MaintenanceDto>(query);

            return result;
        }
    }
}
