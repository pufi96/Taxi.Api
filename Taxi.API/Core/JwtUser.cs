using System.Collections.Generic;
using Taxi.Domain;

namespace Taxi.API.Core
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }

        public int Id { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
        public string Username { get; set; }
    }
}
