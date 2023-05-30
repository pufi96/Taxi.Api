using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Taxi.Application.Exceptions;
using Taxi.Application.Logging;
using Taxi.Application.UseCases;
using Taxi.Domain;

namespace Taxi.Implementation
{
    public class UseCaseHandler
    {
        private IExceptionLogger _logger;
        private IApplicationUser _user;
        private IUseCaseLogger _useCaseLogger;

        public UseCaseHandler(
            IExceptionLogger logger,
            IApplicationUser user,
            IUseCaseLogger useCaseLogger)
        {
            _logger = logger;
            _user = user;
            _useCaseLogger = useCaseLogger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(command, data);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(EfUseCase<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(query, data);
                var response = query.Execute(data);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        private void HandleLoggingAndAuthorization<TRequest>(EfUseCase useCase, TRequest data)
        {
            //var isAuthorized = _user.UseCaseIds.Contains(useCase.Id);

            //var log = new UseCaseLog
            //{
            //    User = _user.Identity,
            //    ExecutionDateTime = DateTime.UtcNow,
            //    UseCaseName = useCase.Name,
            //    UserId = _user.Id,
            //    Data = JsonConvert.SerializeObject(data),
            //    IsAuthorized = isAuthorized
            //};

            //_useCaseLogger.Log(log);

            //if (!isAuthorized)
            //{
            //    throw new ForbiddenUseCaseExecutionException(useCase.Name, _user.Identity);
            //}
        }
    }
}