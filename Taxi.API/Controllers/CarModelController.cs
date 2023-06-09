using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCaseHandling;
using Taxi.Application.UseCases.Commands.CarModel;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.CarModel;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarModelController : ControllerBase
    {
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public CarModelController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<CarModelController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCarModelsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<CarModelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCarModelQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<CarModelController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCarModelDto request, [FromServices] ICreateCarModelCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<CarModelController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] CarModelDto request, [FromServices] IEditCarModelCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
