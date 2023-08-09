using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCaseHandling;
using Taxi.Application.UseCases.Commands.Ride;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;
using Taxi.Implementation.UseCases.Queries.DapperRides;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public RideController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<RideController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetRidesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }
        // GET api/<RideController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindRideQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }
        
        // GET api/<RideController>/findShiftRide/5
        [HttpGet("findShiftRides/{id}")]
        public IActionResult Get(int id, [FromServices] IFindShiftRidesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<RideController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRideDto request, [FromServices] ICreateRideCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<RideController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] RideDto request, [FromServices] IEditRideCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
