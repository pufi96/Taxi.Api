using System.Collections.Generic;

namespace Taxi.Application.UseCases.DTO
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Earnings { get; set; }
        public int UserRoleId { get; set; }
    }

    public class EditUserDto : BaseDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Earnings { get; set; }
        public int UserRoleId { get; set; }
    }

    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Earnings { get; set; }
        public int UserRoleId { get; set; }
    }
}
