using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases
{
    public interface ICommand<TRequest> : EfUseCase
    {
        void Execute(TRequest request);
    }
}
