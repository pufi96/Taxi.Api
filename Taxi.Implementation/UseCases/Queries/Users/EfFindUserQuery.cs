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
using Taxi.Application.UseCases.Queries.User;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.Users
{
    public class EfFindUserQuery : EfUseCase, IFindUserQuery
    {
        public EfFindUserQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 26;

        public string Name => "Find User";

        public string Description => "Find User";

        public UserDtoShift Execute(int id)
        {
            var query = Context.Users.Include(x => x.Shifts).ThenInclude(x => x.Rides).ThenInclude(x => x.InDebteds).ThenInclude(x => x.Debtor)
                                     .Include(x => x.Shifts).ThenInclude(x => x.Rides).ThenInclude(x => x.LocationPrice)
                                     .Include(x => x.Shifts).ThenInclude(x => x.Car).ThenInclude(x => x.FuelType)
                                     .Include(x => x.Shifts).ThenInclude(x => x.Car).ThenInclude(x => x.CarModel).ThenInclude(x => x.CarBrand)
                                     .FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(User), id);
            }

            UserDtoShift result = Mapper.Map<UserDtoShift>(query);

            return result;
        }
    }
}
