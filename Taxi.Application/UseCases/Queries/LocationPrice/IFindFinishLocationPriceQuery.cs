using System.Collections.Generic;
using Taxi.Application.UseCases.DTO;

namespace Taxi.Application.UseCases.Queries.LocationPrice
{
    public interface IFindFinishLocationPriceQuery : IQuery<int, IEnumerable<LocationPricesDto>>
    {
    }
}
