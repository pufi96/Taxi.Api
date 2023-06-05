using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private UseCaseHandler _handler;

        public LocationPriceController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<LocationPriceController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetLocationPricesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<LocationPriceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindLocationPriceQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<LocationPriceController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateLocationPricesDto request, [FromServices] ICreateLocationPriceCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<LocationPriceController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LocationPricesDto request, [FromServices] IEditLocationPriceCommand command)
        {
            request.Id = id;
            _handler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
