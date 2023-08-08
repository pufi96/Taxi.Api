using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.CarModel;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperCarModels
{
    public class DapperGetCarModelsQuery : DapperUseCase, IGetCarModelsQuery
    {
        public DapperGetCarModelsQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 3;

        public string Name => "Get CarModels";

        public string Description => "Get CarModels";

        public IEnumerable<CarModelDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM CarModels";
            using (var connection = Context.CreateConnection())
            {
                var carModels = connection.Query<CarModelDto>(query);
                return carModels.AsList();
            }
        }
    }
}
