using Taxi.Application.UseCases.DTO;

namespace Taxi.Application.UseCases.Queries.LocationPrice
{
    public interface IFindLocationPriceQuery : IQuery<int, LocationPricesDto>
    {
    }
}
