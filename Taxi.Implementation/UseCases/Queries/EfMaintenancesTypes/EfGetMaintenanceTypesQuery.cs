using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

namespace Taxi.Implementation.UseCases.Queries.MaintenancesTypes
{
    public class EfGetMaintenanceTypesQuery : EfUseCase, IGetMaintenanceTypesQuery
    {
        public EfGetMaintenanceTypesQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 17;

        public string Name => "Get MaintenanceTypes";

        public string Description => "Get MaintenanceTypes";

        public IEnumerable<MaintenanceTypeDto> Execute(BaseSearch search)
        {
            var query = Context.MaintenanceTypes.AsQueryable();

            IEnumerable<MaintenanceTypeDto> result = Mapper.Map<IEnumerable<MaintenanceTypeDto>>(query.ToList());

            return result;
        }
    }
}
