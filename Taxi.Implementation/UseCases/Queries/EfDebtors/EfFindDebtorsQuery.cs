using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.EfDebtors
{
    public class EfFindDebtorsQuery : EfUseCase, IFindDebtorsQuery
    {
        public EfFindDebtorsQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Find Debtor";

        public string Description => "Find Debtors";

        public DebtorDto Execute(int id)
        {
            var query = Context.Debtors.Include(x => x.InDebteds).ThenInclude(x => x.Ride).ThenInclude(x => x.LocationPrice)
                                   .Include(x => x.DebtCollections)
                                   .FirstOrDefault(x => x.Id == id & x.IsActive);

            DebtorDto result = Mapper.Map<DebtorDto>(query);

            return result;
        }
    }
}
