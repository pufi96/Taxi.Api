using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.Shift
{
    internal class EfGetShiftsQuery : EfUseCase, IGetShiftQuery
    {
        public EfGetShiftsQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Get Shifts";

        public string Description => "Get Shifts";

        public IEnumerable<ShiftDto> Execute(BaseSearch search)
        {
            var query = Context.Shifts.Include(x => x.Rides).ThenInclude(x => x.InDebteds).ThenInclude(x => x.Debtor).ThenInclude(x => x.DebtCollections)
                                    .Include(x => x.Rides).ThenInclude(x => x.LocationPrice)
                                    .Include(x => x.User)
                                    .Include(x => x.Car).ThenInclude(x => x.FuelType)
                                    .Include(x => x.Car).ThenInclude(x => x.CarModel).ThenInclude(x => x.CarBrand)
                                    .AsQueryable();

            IEnumerable<ShiftDto> result = Mapper.Map<IEnumerable<ShiftDto>>(query.ToList());

            return result;
        }
    }
}
