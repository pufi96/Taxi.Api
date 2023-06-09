using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCaseHandling;
using Taxi.Application.UseCases.Commands.Location;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.Application.UseCases.Queries.Location;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public LocationController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<LocationController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetLocationsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindLocationQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<LocationController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateLocationDto request, [FromServices] ICreateLocationCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<LocationController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] LocationDto request, [FromServices] IEditLocationCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
