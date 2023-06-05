using System.Collections.Generic;
using Taxi.Application;

namespace Taxi.API.Jwt
{
    public class JwtUser : IApplicationUser
    {
        public int Id { get; set;}

        public string Username { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
