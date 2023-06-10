using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.EfCarBrands
{
    public class EfGetCarBrandsQuery : EfUseCase, IGetCarBrandsQuery
    {
        public EfGetCarBrandsQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 1;

        public string Name => "Get CarBrand";

        public string Description => "Get all car brands using EF";

        public IEnumerable<CarBrandDto> Execute(BaseSearch search)
        {

            var query = Context.CarBrands.ProjectTo<CarBrandDto>();
            if (search.Keyword != null)
            {
                query = query.Where(x => x.CarBrandName.Contains(search.Keyword));
            }

            IEnumerable<CarBrandDto> result = query.ToList();

            return result;
        }

    }
}
