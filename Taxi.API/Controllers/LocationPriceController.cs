using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCaseHandling;
using Taxi.Application.UseCases.Commands.LocationPrice;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.LocationPrice;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationPriceController : ControllerBase
    {
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public LocationPriceController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<LocationPriceController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetLocationPricesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        [HttpGet("find-finish/{id}")]
        public IActionResult Get(int id, [FromServices] IFindFinishLocationPriceQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // GET api/<LocationPriceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindLocationPriceQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<LocationPriceController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateLocationPricesDto request, [FromServices] ICreateLocationPriceCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<LocationPriceController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] LocationPricesDto request, [FromServices] IEditLocationPriceCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
