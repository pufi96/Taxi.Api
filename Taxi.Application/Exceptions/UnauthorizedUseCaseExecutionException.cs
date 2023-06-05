using System;

namespace Taxi.Application.Exceptions
{
    public class UnauthorizedUseCaseExecutionException : Exception
    {
        public UnauthorizedUseCaseExecutionException(string username, string useCaseName)
            : base($"There was an unauthorized access attempt by {username} for {useCaseName} use case.")
        {

        }
    }
}
