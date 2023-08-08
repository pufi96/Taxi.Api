using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperFuelTypes
{
    public class DapperGetFuelTypesQuery : DapperUseCase, IGetFuelTypesQuery
    {
        public DapperGetFuelTypesQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 5;

        public string Name => "Get FuelTypes";

        public string Description => "Get FuelTypes";

        public IEnumerable<FuelTypeDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM FuelTypes";
            using (var connection = Context.CreateConnection())
            {
                var fuelTypes = connection.Query<FuelTypeDto>(query);
                return fuelTypes.AsList();
            }
        }
    }
}
