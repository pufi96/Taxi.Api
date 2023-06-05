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
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Maintenance;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.EfMaintenances
{
    public class EfFindMaintenanceQuery : EfUseCase, IFindMaintenanceQuery
    {
        public EfFindMaintenanceQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 12;

        public string Name => "Find Maintenance";

        public string Description => "Find Maintenance";

        public MaintenanceDto Execute(int id)
        {
            var query = Context.Maintenances.Include(x => x.MaintenanceType)
                                    .FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Maintenance), id);
            }


            MaintenanceDto result = Mapper.Map<MaintenanceDto>(query);

            return result;
        }
    }
}
