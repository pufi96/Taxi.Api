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
using Taxi.Application.UseCases.Queries.CarModel;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.EfCarModel
{
    public class EfFindCarModelQuery : EfUseCase, IFindCarModelQuery
    {
        public EfFindCarModelQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 4;

        public string Name => "Find CarModel";

        public string Description => "Find car model using EF";

        public CarModelDto Execute(int id)
        {
            var query = Context.CarModels.Include(x=> x.CarBrand).FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(CarModel), id);
            }


            CarModelDto result = Mapper.Map<CarModelDto>(query);

            return result;
        }
    }
}
