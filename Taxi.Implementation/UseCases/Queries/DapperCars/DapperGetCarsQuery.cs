using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperCars
{
    public class DapperGetCarsQuery : DapperUseCase, IGetCarsQuery
    {
        public DapperGetCarsQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 7;

        public string Name => "Get Cars";

        public string Description => "Get Cars";

        public IEnumerable<CarDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM Cars";
            using (var connection = Context.CreateConnection())
            {
                var cars = connection.Query<CarDto>(query);
                return cars.AsList();
            }
        }
    }
}
