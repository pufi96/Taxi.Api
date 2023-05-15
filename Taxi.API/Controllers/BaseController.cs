using Microsoft.AspNetCore.Mvc;
using Taxi.API.ErrorLogging;
using System;
using Taxi.DatabaseAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IErrorLogger _logger;
        protected BaseController(IErrorLogger logger)
        {
            _logger = logger;
        }
        protected IActionResult Error(Exception ex)
        {
            //Logovati izuzetak
            /*
                -- Jedinstven identifikator greske, kako bismo je locirali (šalje se krajnjem korisniku)
                -- Datum i vreme kada je greška nastala
                -- Korisnik u app
                -- ex.Message - opis greške    
                -- ex.StackTrace - Putanja stack-a gde je nastala greška
            */
            Guid errorId = Guid.NewGuid();
            AppError error = new AppError
            {
                Exception = ex,
                ErrorId = errorId,
                Username = "test"
            };
            _logger.Log(error);
            return StatusCode(500, new { message = $"There was an error, please contact support with this error code: {errorId}." });
        }
    }
}
