using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries
{
    public class EfSearchShiftQuery : EfUseCase, ISearchShiftQuery
    {
        private TaxiDbContext _context;

        public EfSearchShiftQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Shifts Search";

        public string Description => "Searching shifts using EF";

        public IEnumerable<ShiftDto> Execute(ShiftSearch search)
        {
            var query = _context.Shifts
                                .Include(x => x.User)
                                .Where(x => x.IsActive && x.DeletedAt == null)
                                .Include(x => x.Rides)
                                .ThenInclude(x => x.LocationPrice)
                                .Where(x => x.IsActive && x.DeletedAt == null);
            if (!string.IsNullOrEmpty(search.Username))
            {
                query = query.Where(x => x.User.Username.ToLower() == search.Username.ToLower());
            }
            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.CreatedAt >= search.DateFrom.Value);
            }
            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.EditedAt >= search.DateTo.Value);
            }
            // query = query.Where(x => x.EditedAt.HasValue);
            IEnumerable<ShiftDto> result = query.Select(x => new ShiftDto
            {
                Id = x.Id,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                ShiftDate = x.CreatedAt.ToString("yyyy-MM-dd hh:mm:ss"),
                MileageStart = x.MileageStart,
                MileageEnd = x.MileageEnd == null ? 0 : (int)x.MileageEnd,
                Turnover = x.Turnover == null ? 0 : (int)x.Turnover,
                Earnings = x.Earnings == null ? 0 : (int)x.Earnings,
                Expenses = x.Expenses == null ? 0 : (int)x.Expenses,
                Rides = x.Rides.Select(z => new RideDto
                {
                    Id = z.Id,
                    IsLocal = z.IsLocal,
                    Price = z.RidePrice,
                    LocationPrice = new LocationPricesDto
                    {
                        Id = z.LocationPrice.Id,
                        LocationStart = z.LocationPrice.LocationStart.LocationName,
                        LocationEnd = z.LocationPrice.LocationEnd.LocationName
                    }
                })
            }).ToList();
            return result;
        }
    }
}
