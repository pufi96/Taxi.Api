using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.MaintenanceType;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.MaintenancesTypes
{
    public class EfFindMaintenanceTypeQuery : EfUseCase, IFindMaintenanceTypeQuery
    {
        public EfFindMaintenanceTypeQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 18;

        public string Name => "Find MaintenanceTypes";

        public string Description => "Find MaintenanceTypes";

        public MaintenanceTypeDto Execute(int id)
        {
            var query = Context.MaintenanceTypes.FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(MaintenanceType), id);
            }

            MaintenanceTypeDto result = Mapper.Map<MaintenanceTypeDto>(query);

            return result;
        }
    }
}
