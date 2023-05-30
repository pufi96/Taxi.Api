using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.EfCarBrands
{
    public class EfFindCarBrandsQuery : EfUseCase, IFindCarBrandsQuery
    {
        public EfFindCarBrandsQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Find CarBrand";

        public string Description => "Find car brand using EF";

        public CarBrandDto Execute(int id)
        {
            var query = Context.CarBrands.FirstOrDefault(x => x.Id == id & x.IsActive);

            CarBrandDto result = Mapper.Map<CarBrandDto>(query);

            return result;
        }
    }
}
