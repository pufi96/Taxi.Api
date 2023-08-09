using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.EfDebtors
{
    //public class EfGetDebtorsQuery : EfUseCase, IGetDebtorsQuery
    //{
    //    public EfGetDebtorsQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
    //    {
    //    }

    //    public int Id => 3;

    //    public string Name => "Get Debtors";

    //    public string Description => "Get All Debtors";

    //    public IEnumerable<DebtorDtoDebt> Execute(BaseSearch search)
    //    {
    //        var query = Context.Debtors.Include(x => x.DebtCollections)
    //                                    .Include(x => x.InDebteds).ThenInclude(x => x.Ride)
    //                                    .AsQueryable();

    //        if (search.Keyword != null)
    //        {
    //            query = query.Where(x => x.DebtorFirstName.Contains(search.Keyword));
    //        }

    //        var queryResponse = query.ToList();


    //        IEnumerable<DebtorDtoDebt> debtors = queryResponse.Select(x =>
    //        {
    //            var debtor = Mapper.Map<DebtorDtoDebt>(x);
    //            debtor.DebtCollections = x.DebtCollections.Select(d =>
    //            {
    //                var debtCollection = Mapper.Map<DebtCollectionDto>(d);
    //                return debtCollection;
    //            }).ToList();
    //            debtor.Rides = x.InDebteds.Select(r =>
    //            {
    //                var ride = Mapper.Map<RideDto>(r.Ride);
    //                return ride;
    //            }).ToList();
    //            return debtor;
    //        }).ToList();


    //        return debtors;
    //    }
    //}
}
