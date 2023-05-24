using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.Exceptions
{
    public class NotLoggedInException : Exception
    {
        public NotLoggedInException()
            : base($"You need to loggin.")
        {
        }
    }
}
