using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.MaintenanceType;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.MaintenancesTypes
{
    public class EfFindMaintenanceTypesQuery : EfUseCase, IFindMaintenanceTypesQuery
    {
        public EfFindMaintenanceTypesQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Find MaintenanceTypes";

        public string Description => "Find MaintenanceTypes";

        public MaintenanceTypeDto Execute(int id)
        {
            var query = Context.MaintenanceTypes.FirstOrDefault(x => x.Id == id & x.IsActive);

            MaintenanceTypeDto result = Mapper.Map<MaintenanceTypeDto>(query);

            return result;
        }
    }
}
