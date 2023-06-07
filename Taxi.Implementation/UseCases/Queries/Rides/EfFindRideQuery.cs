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
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.Rides
{
    public class EfFindRideQuery : EfUseCase, IFindRideQuery
    {

        public EfFindRideQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 20;

        public string Name => "Find Rides";

        public string Description => "Find Rides";

        public RideDtoDebtor Execute(int id)
        {
            var query = Context.Rides.Include(x => x.InDebteds).ThenInclude(x => x.Debtor)
                                    .Include(x => x.LocationPrice)
                                    .FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Ride), id);
            }

            RideDtoDebtor result = Mapper.Map<RideDtoDebtor>(query);
            result.Debtor = Mapper.Map<DebtorDto>(query.InDebteds.FirstOrDefault());


            return result;
        }
    }
}
