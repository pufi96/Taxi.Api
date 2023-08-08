using System.Collections.Generic;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;

namespace Taxi.Application.UseCases.Queries.DebtCollection
{
    public interface IGetDebtCollectionsQuery : IQuery<int, IEnumerable<DebtCollectionDto>>
    {
    }
}
