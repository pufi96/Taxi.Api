using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperDebtors
{
    public class DapperGetDebtorsQuery : DapperUseCase, IGetDebtorsQuery
    {
        public DapperGetDebtorsQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }
        public int Id => 3;

        public string Name => "Get Debtors";

        public string Description => "Get Debtors";

        public IEnumerable<DebtorDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM Debtors";
            using (var connection = Context.CreateConnection())
            {
                var debtors = connection.Query<DebtorDto>(query);
                return debtors.AsList();
            }
        }
    }
}
