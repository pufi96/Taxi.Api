using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.Logging
{
    public interface IUseCaseLogger
    {
        void Add(UseCaseLogEntry entry);
    }

    public class UseCaseLogEntry
    {
        public string User { get; set; }
        public int UserId { get; set; }
        public object Data { get; set; }
        public string UseCaseName { get; set; }
    }
}
