using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCases.Commands.Car;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private UseCaseHandler _handler;

        public CarController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<CarController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCarsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCarQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<CarController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCarDto request, [FromServices] ICreateCarCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<CarController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] EditCarDto request, [FromServices] IEditCarCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(204);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCarCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
