using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.EfFuelTypes
{
    public class EfGetFuelTypesQuery : EfUseCase, IGetFuelTypesQuery
    {
        public EfGetFuelTypesQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 5;

        public string Name => "Get FuelTypes";

        public string Description => "Get FuelTypes";

        public IEnumerable<FuelTypeDto> Execute(BaseSearch search)
        {
            var query = Context.FuelTypes.AsQueryable();
            if (search.Keyword != null)
            {
                query = query.Where(x => x.FuelTypeName.Contains(search.Keyword));
            }

            IEnumerable<FuelTypeDto> result = Mapper.Map<IEnumerable<FuelTypeDto>>(query.ToList());

            return result;
        }
    }
}
