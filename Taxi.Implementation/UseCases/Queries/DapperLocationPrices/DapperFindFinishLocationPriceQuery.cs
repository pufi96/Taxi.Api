using Dapper;
using System;
using System.Collections.Generic;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.LocationPrice;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperLocationPrices
{
    public class DapperFindFinishLocationPriceQuery : DapperUseCase, IFindFinishLocationPriceQuery
    {
        public DapperFindFinishLocationPriceQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 51;

        public string Name => "Find finish location.";

        public string Description => "Find finish location.";

        public IEnumerable<LocationPricesDto> Execute(int id)
        {
            var query = "SELECT lp.*,ls.LocationName AS LocationStart, le.LocationName AS LocationEnd FROM LocationPrices AS lp LEFT JOIN Locations AS ls ON ls.Id = lp.LocationStartId LEFT JOIN Locations AS le ON le.Id = lp.LocationEndId WHERE ls.Id = @Id OR le.Id = @Id";
            using (var connection = Context.CreateConnection())
            {
                var locationPrice = connection.Query<LocationPricesDto>(query, new { id });
                return locationPrice.AsList();
            }
        }
    }
}
