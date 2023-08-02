using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.Shifts
{
    public class EfFindUserShiftsQuery : EfUseCase, IFindUserShiftsQuery
    {
        public EfFindUserShiftsQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 52;

        public string Name => "Find all finished shifts from user.";

        public string Description => "Find all finished shifts from user.";

        public ShiftDtoUserRides Execute(int id)
        {
            var query = Context.Shifts.Include(x => x.Rides).ThenInclude(x => x.InDebteds).ThenInclude(x => x.Debtor)
                                    .Include(x => x.Rides).ThenInclude(x => x.LocationPrice).ThenInclude(x => x.LocationStart)
                                    .Include(x => x.Rides).ThenInclude(x => x.LocationPrice).ThenInclude(x => x.LocationEnd)
                                    .Include(x => x.User)
                                    .Include(x => x.Car).ThenInclude(x => x.FuelType)
                                    .Include(x => x.Car).ThenInclude(x => x.CarModel).ThenInclude(x => x.CarBrand)
                                    .Where(x => x.UserId == id & x.ShiftEnd != null)
                                    .FirstOrDefault(x => x.IsActive);

            ShiftDtoUserRides result = Mapper.Map<ShiftDtoUserRides>(query);

            return result;
        }
    }
}
