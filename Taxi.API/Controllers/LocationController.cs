using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private UseCaseHandler _handler;

        public LocationController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<LocationController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetLocationsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindLocationQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<LocationController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateLocationDto request, [FromServices] ICreateLocationCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LocationDto request, [FromServices] IEditLocationCommand command)
        {
            request.Id = id;
            _handler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
