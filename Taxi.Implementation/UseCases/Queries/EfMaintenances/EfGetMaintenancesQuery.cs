using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.Application.UseCases.Queries.Maintenance;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.EfMaintenances
{
    public class EfGetMaintenancesQuery : EfUseCase, IGetMaintenancesQuery
    {
        public EfGetMaintenancesQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 11;

        public string Name => "Get Maintenance";

        public string Description => "Get Maintenance";

        public IEnumerable<MaintenanceDtoCar> Execute(BaseSearch search)
        {

            var query = Context.Maintenances.AsQueryable();
            //if (search.Keyword != null)
            //{
            //    query = query.Where(x => x.FuelTypeName.Contains(search.Keyword));
            //}

            var queryResponse = query.ToList();

            IEnumerable<MaintenanceDtoCar> maintenances = queryResponse.Select(x =>
            {
                var maintenance = Mapper.Map<MaintenanceDtoCar>(x);
                maintenance.Car = Mapper.Map<CarDto>(x.Car);
                return maintenance;
            }).ToList();

            return maintenances;
        }
    }
}
