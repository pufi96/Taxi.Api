using Dapper;
using System.Collections.Generic;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Application.UseCases.Queries.User;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperUsers
{
    public class DapperGetUsersQuery : DapperUseCase, IGetUsersQuery
    {
        public DapperGetUsersQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 25;

        public string Name => "Get Users";

        public string Description => "Find User";

        public IEnumerable<UserDto> Execute(BaseSearch search)
        {
            var query = "SELECT * FROM Users";
            using (var connection = Context.CreateConnection())
            {
                var users = connection.Query<UserDto>(query);
                return users.AsList();
            }
        }
    }
}
