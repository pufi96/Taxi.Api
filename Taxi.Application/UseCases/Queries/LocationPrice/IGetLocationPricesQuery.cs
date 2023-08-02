﻿using System.Collections.Generic;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;

namespace Taxi.Application.UseCases.Queries.LocationPrice
{
    public interface IGetLocationPricesQuery : IQuery<BaseSearch, IEnumerable<LocationPricesDto>>
    {
    }
}
