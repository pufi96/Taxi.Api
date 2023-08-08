using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.User;
using Taxi.DatabaseAccess;
using Taxi.Domain;

namespace Taxi.Implementation.UseCases.Queries.DapperUsers
{
    public class DapperFindUserQuery : DapperUseCase, IFindUserQuery
    {
        public DapperFindUserQuery(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 26;

        public string Name => "Find User using dapper";

        public string Description => "Find User using dapper";

        public UserDto Execute(int id)
        {
            var query = "SELECT * FROM Users WHERE Id = @id";
            using (var connection = Context.CreateConnection())
            {
                var users = connection.QueryFirstOrDefault<UserDto>(query, new { id });
                return users;
            }
        }
    }
}
