using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperCarBrands
{
    public class DapperGetCarBrandsQuery : DapperUseCase, IGetCarBrandsQuery
    {
        public DapperGetCarBrandsQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 1;

        public string Name => "Get CarBrand";

        public string Description => "Get all car brands";

        public IEnumerable<CarBrandDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM CarBrands";
            using (var connection = Context.CreateConnection())
            {
                var carBrands = connection.Query<CarBrandDto>(query);
                return carBrands.AsList();
            }
        }
    }
}
