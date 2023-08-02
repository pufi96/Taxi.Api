using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.LocationPrice;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.LocationPrices
{
    public class EfFindFinishLocationPriceQuery : EfUseCase, IFindFinishLocationPriceQuery
    {
        public EfFindFinishLocationPriceQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 51;

        public string Name => "Find finish location.";

        public string Description => "Find finish location.";

        public IEnumerable<LocationPricesDto> Execute(int id)
        {
            var query = Context.LocationPrices.Include(x => x.LocationStart)
                                               .Include(x => x.LocationEnd)
                                               .Where(x => x.LocationStartId == id || x.LocationEndId == id)
                                               .AsQueryable();

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(LocationPrice), id);
            }

            IEnumerable<LocationPricesDto> result = Mapper.Map<IEnumerable<LocationPricesDto>>(query.ToList());

            return result;
        }
    }
}
