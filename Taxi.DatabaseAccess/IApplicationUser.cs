using System.Collections.Generic;

namespace Taxi.Domain
{
    public interface IApplicationUser
    {
        int Id { get; }
        string Username { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
