using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCases.Commands.Ride;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private UseCaseHandler _handler;

        public RideController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<RideController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetRidesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<RideController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindRideQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<RideController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRideDto request, [FromServices] ICreateRideCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<RideController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RideDto request, [FromServices] IEditRideCommand command)
        {
            request.Id = id;
            _handler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
