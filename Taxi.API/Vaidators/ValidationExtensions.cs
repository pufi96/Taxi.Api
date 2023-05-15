using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Taxi.API.DTO;

namespace Taxi.API.Vaidators
{
    public static class ValidationExtensions
    {
        public static UnprocessableEntityObjectResult ToUnprocessableEntity(this ValidationResult result)
        {
            var errors = result.Errors.Select(x => new ClientErrorDto
            {
                Error = x.ErrorMessage,
                Property = x.PropertyName
            });

            return new UnprocessableEntityObjectResult(errors);
        }
    }
}
