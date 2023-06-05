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
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.EfCars
{
    public class EfFindCarQuery : EfUseCase, IFindCarQuery
    {
        public EfFindCarQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 8;

        public string Name => "Find Cars";

        public string Description => "Find Cars";

        public CarDto Execute(int id)
        {
            var query = Context.Cars.Include(x => x.CarModel).ThenInclude(x => x.CarBrand)
                                    .Include(x => x.Maintenances).ThenInclude(x => x.MaintenaceType)
                                    .FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Car), id);
            }

            CarDto result = Mapper.Map<CarDto>(query);

            return result;
        }
    }
}
