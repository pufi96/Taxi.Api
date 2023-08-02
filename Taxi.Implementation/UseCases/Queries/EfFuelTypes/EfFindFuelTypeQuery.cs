using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.EfFuelTypes
{
    public class EfFindFuelTypeQuery : EfUseCase, IFindFuelTypeQuery
    {
        public EfFindFuelTypeQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 6;

        public string Name => "Find FuelTypes";

        public string Description => "Find FuelTypes";

        public FuelTypeDto Execute(int id)
        {
            var query = Context.FuelTypes.FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(FuelType), id);
            }


            FuelTypeDto result = Mapper.Map<FuelTypeDto>(query);

            return result;
        }
    }
}
