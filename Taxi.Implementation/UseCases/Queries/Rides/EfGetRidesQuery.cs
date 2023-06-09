﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.MaintenacesType;
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.Rides
{
    public class EfGetRidesQuery : EfUseCase, IGetRidesQuery
    {
        public EfGetRidesQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 19;

        public string Name => "Get Rides";

        public string Description => "Get Rides";

        public IEnumerable<RideDtoDebtor> Execute(BaseSearch search)
        {
            var query = Context.Rides.Include(x => x.LocationPrice)
                                    .Include(x => x.InDebteds).ThenInclude(x => x.Debtor)
                                    .AsQueryable();

            var queryResponse = query.ToList();

            IEnumerable<RideDtoDebtor> rides = queryResponse.Select(x =>
            {
                var ride = Mapper.Map<RideDtoDebtor>(x);
                ride.Debtor= x.InDebteds.Select(d =>
                {
                    DebtorDto debtor = Mapper.Map<DebtorDto>(d.Debtor);
                    return debtor;
                }).FirstOrDefault();
                return ride;
            }).ToList();

            return rides;
        }
    }
}
