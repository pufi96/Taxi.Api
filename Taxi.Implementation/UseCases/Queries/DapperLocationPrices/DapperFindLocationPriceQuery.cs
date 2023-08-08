using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.LocationPrice;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperLocationPrices
{
    public class DapperFindLocationPriceQuery : DapperUseCase, IFindLocationPriceQuery
    {
        public DapperFindLocationPriceQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 14;

        public string Name => "Find LocationPrice";

        public string Description => "Find LocationPrice";

        public LocationPricesDto Execute(int id)
        {
            var query = "SELECT * FROM LocationPrices WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var locationPrice = connection.QueryFirstOrDefault<LocationPricesDto>(query, new { id });
                return locationPrice;
            }
        }
    }
}
