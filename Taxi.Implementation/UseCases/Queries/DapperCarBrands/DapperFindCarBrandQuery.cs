using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperCarBrands
{
    public class DapperFindCarBrandQuery : DapperUseCase, IFindCarBrandQuery
    {
        public DapperFindCarBrandQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }
        public int Id => 2;

        public string Name => "Find CarBrand";

        public string Description => "Find CarBrand";

        public CarBrandDto Execute(int id)
        {
            var query = "SELECT * FROM CarBrands WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var carBrand = connection.QueryFirstOrDefault<CarBrandDto>(query, new { id });
                return carBrand;
            }
        }
    }
}
