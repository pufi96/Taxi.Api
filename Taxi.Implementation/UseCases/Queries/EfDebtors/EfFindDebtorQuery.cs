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
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Queries.EfDebtors
{
    public class EfFindDebtorQuery : EfUseCase, IFindDebtorQuery
    {
        public EfFindDebtorQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 10;

        public string Name => "Find Debtor";

        public string Description => "Find Debtors";

        public DebtorDtoDebt Execute(int id)
        {
            var query = Context.Debtors.Include(x => x.InDebteds).ThenInclude(x => x.Ride).ThenInclude(x => x.LocationPrice)
                                   .Include(x => x.DebtCollections)
                                   .FirstOrDefault(x => x.Id == id & x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Debtor), id);
            }

            DebtorDtoDebt result = Mapper.Map<DebtorDtoDebt>(query);

            return result;
        }
    }
}
