using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperDebtors
{
    public class DapperFindDebtorQuery : DapperUseCase, IFindDebtorQuery
    {
        public DapperFindDebtorQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 10;

        public string Name => "Find Debtor";

        public string Description => "Find Debtor";

        public DebtorDto Execute(int id)
        {
            var query = "SELECT * FROM Debtors WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var debtor = connection.QueryFirstOrDefault<DebtorDto>(query, new { id });
                return debtor;
            }
        }
    }
}
