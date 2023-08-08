using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.LocationPrice;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperLocationPrices
{
    public class DapperGetLocationPricesQuery : DapperUseCase, IGetLocationPricesQuery
    {
        public DapperGetLocationPricesQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 13;

        public string Name => "Get LocationPrices";

        public string Description => "Get LocationPrices";

        public IEnumerable<LocationPricesDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM LocationPrices";
            using (var connection = Context.CreateConnection())
            {
                var locationPrices = connection.Query<LocationPricesDto>(query);
                return locationPrices.AsList();
            }
        }
    }
}
