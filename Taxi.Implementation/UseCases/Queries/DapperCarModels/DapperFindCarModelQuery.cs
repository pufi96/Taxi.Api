using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.CarModel;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperCarModels
{
    public class DapperFindCarModelQuery : DapperUseCase, IFindCarModelQuery
    {
        public DapperFindCarModelQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 4;

        public string Name => "Find CarModel";

        public string Description => "Find car model using EF";

        public CarModelDto Execute(int id)
        {
            var query = "SELECT * FROM CarModels WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var carModel = connection.QueryFirstOrDefault<CarModelDto>(query, new { id });
                return carModel;
            }
        }
    }
}
