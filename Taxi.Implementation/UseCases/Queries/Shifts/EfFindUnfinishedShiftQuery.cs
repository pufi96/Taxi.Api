using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.Shifts
{
    //public class EfFindUnfinishedShiftQuery : EfUseCase, IFindUnfinishedShiftQuery
    //{
    //    public EfFindUnfinishedShiftQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
    //    {
    //    }

    //    public int Id => 50;

    //    public string Name => "Find unfinished shift";

    //    public string Description => "Find unfinished shift";

    //    public ShiftDto Execute(int id)
    //    {
    //        var query = Context.Shifts.Include(x => x.Rides).ThenInclude(x => x.InDebteds).ThenInclude(x => x.Debtor)
    //                                .Include(x => x.Rides).ThenInclude(x => x.LocationPrice).ThenInclude(x => x.LocationStart)
    //                                .Include(x => x.Rides).ThenInclude(x => x.LocationPrice).ThenInclude(x => x.LocationEnd)
    //                                .Include(x => x.User)
    //                                .Include(x => x.Car).ThenInclude(x => x.FuelType)
    //                                .Include(x => x.Car).ThenInclude(x => x.CarModel).ThenInclude(x => x.CarBrand)
    //                                .Where(x => x.UserId == id & x.ShiftEnd == null)
    //                                .FirstOrDefault(x => x.IsActive);

    //        ShiftDto result = Mapper.Map<ShiftDto>(query);

    //        return result;
    //    }
    //}
}
