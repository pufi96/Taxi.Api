using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.EfCars
{
    public class EfGetCarsQuery : EfUseCase, IGetCarsQuery
    {
        public EfGetCarsQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 7;

        public string Name => "Get Cars";

        public string Description => "Get Cars";

        public IEnumerable<CarDtoMaintenances> Execute(BaseSearch search)
        {
            var query = Context.Cars.Include(x => x.CarModel).ThenInclude(x => x.CarBrand)
                                    .Include(x => x.Maintenances).ThenInclude(x => x.MaintenanceType)
                                    .Include(x => x.FuelType)
                                    .AsQueryable();

            if (search.Keyword != null)
            {
                query = query.Where(x => x.CarModel.CarModelName.Contains(search.Keyword));
            }

            var queryResponse = query.ToList();

            IEnumerable<CarDtoMaintenances> cars = queryResponse.Select(x =>
            {
                var car = Mapper.Map<CarDtoMaintenances>(x);
                car.FuelType.FuelTypeName = x.FuelType.FuelTypeName;
                car.CarModel.CarModelName = x.CarModel.CarModelName;
                car.Maintenances = x.Maintenances.Select(m =>
                {
                    var maintenance = Mapper.Map<MaintenanceDto>(m);
                    maintenance.MaintenanceType.MaintenanceTypeName = m.MaintenanceType.MaintenanceTypeName;
                    return maintenance;
                }).ToList();
                return car;
            }).ToList();

            return cars;
        }
    }
}
