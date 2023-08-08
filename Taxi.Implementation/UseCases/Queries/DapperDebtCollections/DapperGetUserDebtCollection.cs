using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.DebtCollection;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperDebtCollections
{
    public class DapperGetUserDebtCollection : DapperUseCase, IGetDebtCollectionsQuery
    {
        public DapperGetUserDebtCollection(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 54;

        public string Name => "Get DebtCollection";

        public string Description => "Get DebtCollection";

        public IEnumerable<DebtCollectionDto> Execute(int id)
        {
            var query = "SELECT * FROM DebtCollections WHERE DebtorId = @id";
            using (var connection = Context.CreateConnection())
            {
                var debtCollections = connection.Query<DebtCollectionDto>(query, new {id});
                return debtCollections.AsList();
            }
        }
    }
}
