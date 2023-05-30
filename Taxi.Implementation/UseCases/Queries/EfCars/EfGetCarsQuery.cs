using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.EfCars
{
    public class EfGetCarsQuery : EfUseCase, IGetCarsQuery
    {
        public EfGetCarsQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Get Cars";

        public string Description => "Get Cars";

        public IEnumerable<CarDto> Execute(CarSearch search)
        {
            var query = Context.Cars.Include(x => x.CarModel).ThenInclude(x => x.CarBrand)
                                    .Include(x => x.Maintenances).ThenInclude(x => x.MaintenaceType)
                                    .AsQueryable();

            if (search.CarModelName != null)
            {
                query = query.Where(x => x.CarModel.CarModelName.Contains(search.CarModelName));
            }
            if (search.CarBrandName != null)
            {
                query = query.Where(x => x.CarModel.CarBrand.CarBrandName.Contains(search.CarBrandName));
            }

            IEnumerable<CarDto> result = Mapper.Map<IEnumerable<CarDto>>(query.ToList());

            return result;
        }
    }
}
