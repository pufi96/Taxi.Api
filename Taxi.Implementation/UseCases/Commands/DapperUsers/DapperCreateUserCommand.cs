using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Email;
using Taxi.Application.UseCases.Commands.User;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperUsers
{
    public class DapperCreateUserCommand : DapperUseCase, ICreateUserCommand
    {
        private CreateUserValidator _validator;
        private IEmailSender _sender;
        public DapperCreateUserCommand(DapperContext context, IApplicationUser user, IEmailSender sender, CreateUserValidator validator) : base(context, user)
        {
            _sender = sender;
            _validator = validator;
        }

        public int Id => 46;

        public string Name => "Create User";

        public string Description => "Create User";

        public void Execute(CreateUserDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO Users 
                    (Username, Password, Email, FirstName, LastName, Earnings, UserRoleId)
                    VALUES (@Username, @Password, @Email, @FirstName, @LastName, @Earnings, @UserRoleId)";

                var password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                DynamicParameters param = new DynamicParameters();
                param.Add("@Username", request.Username);
                param.Add("@Password", password);
                param.Add("@Email", request.Email);
                param.Add("@FirstName", request.FirstName);
                param.Add("@LastName", request.LastName);
                param.Add("@Earnings", request.Earnings);
                param.Add("@UserRoleId", request.UserRoleId);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
