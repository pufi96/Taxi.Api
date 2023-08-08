using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperFuelTypes
{
    public class DapperFindFuelTypeQuery : DapperUseCase, IFindFuelTypeQuery
    {
        public DapperFindFuelTypeQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 6;

        public string Name => "Find FuelTypes";

        public string Description => "Find FuelTypes";

        public FuelTypeDto Execute(int id)
        {
            var query = "SELECT * FROM FuelTypes WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var fuelType = connection.QueryFirstOrDefault<FuelTypeDto>(query, new { id });
                return fuelType;
            }
        }
    }
}
