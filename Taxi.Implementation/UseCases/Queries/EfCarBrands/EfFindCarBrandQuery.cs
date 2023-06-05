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
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using static System.Collections.Specialized.BitVector32;

namespace Taxi.Implementation.UseCases.Queries.EfCarBrands
{
    public class EfFindCarBrandQuery : EfUseCase, IFindCarBrandQuery
    {
        public EfFindCarBrandQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 2;

        public string Name => "Find CarBrand";

        public string Description => "Find car brand using EF";

        public MaintenanceDto Execute(int id)
        {
            var query = Context.CarBrands.FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Maintenance), id);
            }

            MaintenanceDto result = Mapper.Map<MaintenanceDto>(query);

            return result;
        }
    }
}
