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
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.Shifts
{
    public class EfFindShiftsQuery : EfUseCase, IFindShiftQuery
    {
        public EfFindShiftsQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 24;

        public string Name => "Find Shifts";

        public string Description => "Find Shifts";

        public ShiftDtoUserRides Execute(int id)
        {
            var query = Context.Shifts.Include(x => x.Rides).ThenInclude(x => x.InDebteds).ThenInclude(x => x.Debtor).ThenInclude(x => x.DebtCollections)
                                    .Include(x => x.Rides).ThenInclude(x => x.LocationPrice)
                                    .Include(x => x.User)
                                    .Include(x => x.Car).ThenInclude(x => x.FuelType)
                                    .Include(x => x.Car).ThenInclude(x => x.CarModel).ThenInclude(x => x.CarBrand)
                                    .FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Shift), id);
            }

            ShiftDtoUserRides result = Mapper.Map<ShiftDtoUserRides>(query);

            return result;
        }
    }
}
