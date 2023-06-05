using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FuelTypeController : ControllerBase
    {
        private UseCaseHandler _handler;
        public FuelTypeController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<FuelTypesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetFuelTypesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<FuelTypesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindFuelTypeQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }
    }
}
