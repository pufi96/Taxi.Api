using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.EfDebtors
{
    public class EfGetDebtorsQuery : EfUseCase, IGetDebtorsQuery
    {
        public EfGetDebtorsQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Get Debtors";

        public string Description => "Get All Debtors";

        public IEnumerable<DebtorDto> Execute(BaseSearch search)
        {
            var query = Context.Debtors.Include(x => x.DebtCollections)
                                        .Include(x => x.InDebteds).ThenInclude(x => x.Ride)
                                        .AsQueryable();
            //if (search.Keyword != null)
            //{
            //    query = query.Where(x => x.CarBrandName.Contains(search.Keyword));
            //}

            IEnumerable<DebtorDto> result = Mapper.Map<IEnumerable<DebtorDto>>(query.ToList());


            return result;
        }
    }
}
