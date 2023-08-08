using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperCars
{
    public class DapperFindCarQuery : DapperUseCase, IFindCarQuery
    {
        public DapperFindCarQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 8;

        public string Name => "Find Cars";

        public string Description => "Find Cars";

        public CarDto Execute(int id)
        {
            var query = "SELECT * FROM Cars WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var car = connection.QueryFirstOrDefault<CarDto>(query, new { id });
                return car;
            }
        }
    }
}
