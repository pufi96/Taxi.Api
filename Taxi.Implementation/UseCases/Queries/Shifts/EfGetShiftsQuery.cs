using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using Taxi.Implementation.Extensions;

namespace Taxi.Implementation.UseCases.Queries.Shifts
{
    public class EfGetShiftsQuery : EfUseCase, IGetShiftsQuery
    {
        public EfGetShiftsQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 23;

        public string Name => "Get Shifts";

        public string Description => "Get Shifts";

        public PagedResponse<ShiftDtoUserRides> Execute(ShiftSearch search)
        {
            var query = Context.Shifts.Include(x => x.Rides).ThenInclude(x => x.InDebteds).ThenInclude(x => x.Debtor)
                                    .Include(x => x.Rides).ThenInclude(x => x.LocationPrice)
                                    .Include(x => x.User)
                                    .Include(x => x.Car).ThenInclude(x => x.FuelType)
                                    .Include(x => x.Car).ThenInclude(x => x.CarModel).ThenInclude(x => x.CarBrand)
                                    .AsQueryable();

            var response = query.ToPagedResponse(search,x => x);

            var result = new PagedResponse<ShiftDtoUserRides>();

            result.ItemsPerPage = response.ItemsPerPage;
            result.TotalCount = response.TotalCount;
            result.CurrentPage = response.CurrentPage;

            result.Items = response.Items.Select(x => Mapper.Map<ShiftDtoUserRides>(x));


            return result;
        }
    }
}
