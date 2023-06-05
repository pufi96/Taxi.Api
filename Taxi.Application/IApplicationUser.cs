using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application
{
    public interface IApplicationUser
    {
        int Id { get; }
        string Username { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
