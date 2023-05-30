using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases
{
    public interface EfUseCase
    {
        int Id { get; }
        string Name { get; }
        public string Description { get; }
    }
}
