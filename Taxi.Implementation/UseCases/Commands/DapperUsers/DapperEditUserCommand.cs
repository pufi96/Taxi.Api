using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.User;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperUsers
{
    public class DapperEditUserCommand : DapperUseCase, IEditUserCommand
    {
        private EditUserValidator _validator;
        public DapperEditUserCommand(DapperContext context, IApplicationUser user, EditUserValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 48;

        public string Name => "Edit User";

        public string Description => "Edit User";

        public void Execute(EditUserDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  Users 
                    SET 
                    Username = @Username,
                    Password = @Password,
                    Email = @Email,
                    FirstName = @FirstName,
                    LastName = @LastName,
                    Earnings = @Earnings,
                    UserRoleId = @UserRoleId,s
                    EditedAt = @EditedAt
                    WHERE Id = @Id"
                ;

                DynamicParameters param = new DynamicParameters();

                var password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                param.Add("@Username", request.Username);
                param.Add("@Password", password);
                param.Add("@Email", request.Email);
                param.Add("@FirstName", request.FirstName);
                param.Add("@LastName", request.LastName);
                param.Add("@Earnings", request.Earnings);
                param.Add("@UserRoleId", request.UserRoleId);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
