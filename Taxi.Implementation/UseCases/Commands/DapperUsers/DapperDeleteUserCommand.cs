using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Commands.User;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Commands.DapperUsers
{
    public class DapperDeleteUserCommand : DapperUseCase, IDeleteUserCommand
    {
        public DapperDeleteUserCommand(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 47;

        public string Name => "Delete User";

        public string Description => "Delete User";

        public void Execute(int id)
        {
            using (var connection = Context.CreateConnection())
            {
                var query = "SELECT * FROM Users WHERE Id = @id";
                var car = connection.QueryFirstOrDefault<UserDto>(query, new { id });
                if (car == null)
                {
                    throw new EntityNotFoundException(nameof(User), id);
                }
                var updateQuery = @"
                    UPDATE  Users 
                    SET 
                    IsActive = @IsActive
                    DeletedAt = @DeletedAt
                    WHERE Id = @Id";

                DynamicParameters param = new DynamicParameters();
                param.Add("@IsActive", false);
                param.Add("@DeletedAt", DateTime.UtcNow);
                param.Add("@Id", id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
