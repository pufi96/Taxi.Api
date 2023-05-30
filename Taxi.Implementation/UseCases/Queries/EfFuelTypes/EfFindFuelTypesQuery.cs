using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.EfFuelTypes
{
    public class EfFindFuelTypesQuery : EfUseCase, IFindFuelTypesQuery
    {
        public EfFindFuelTypesQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Find FuelTypes";

        public string Description => "Find FuelTypes";

        public FuelTypeDto Execute(int id)
        {
            var query = Context.FuelTypes.FirstOrDefault(x => x.Id == id & x.IsActive);

            FuelTypeDto result = Mapper.Map<FuelTypeDto>(query);

            return result;
        }
    }
}
