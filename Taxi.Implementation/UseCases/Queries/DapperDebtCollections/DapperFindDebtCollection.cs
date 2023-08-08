using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.DebtCollection;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperDebtCollections
{
    public class DapperFindDebtCollection : DapperUseCase, IFindDebtCollectionQuery
    {
        public DapperFindDebtCollection(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 55;

        public string Name => "Find DebtCollection";

        public string Description => "Find DebtCollection";

        public DebtCollectionDto Execute(int id)
        {
            var query = "SELECT * FROM DebtCollections WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var debtCollections = connection.QueryFirstOrDefault<DebtCollectionDto>(query, new { id });
                return debtCollections;
            }
        }
    }
}
