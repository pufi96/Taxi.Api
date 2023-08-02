using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.CarModel;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Queries.EfCarModel
{
    public class EfGetCarModelsQuery : EfUseCase, IGetCarModelsQuery
    {
        public EfGetCarModelsQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 3;

        public string Name => "Get CarModel";

        public string Description => "Get all car models using EF";

        public IEnumerable<CarModelDto> Execute(BaseSearch search)
        {
            var query = Context.CarModels.Include(x => x.CarBrand).AsQueryable();

            if (search.Keyword != null)
            {
                query = query.Where(x => x.CarModelName.Contains(search.Keyword));
            }

            IEnumerable<CarModelDto> result = Mapper.Map<IEnumerable<CarModelDto>>(query.ToList());

            return result;
        }
    }
}
