using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCaseHandling;
using Taxi.Application.UseCases.Commands.Maintenance;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Maintenance;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaintenanceController : ControllerBase
    {
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public MaintenanceController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<MaintenanceController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetMaintenancesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<MaintenanceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindMaintenanceQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<MaintenanceController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateMaintenanceDto request, [FromServices] ICreateMaintenanceCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<MaintenanceController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] EditMaintenanceDto request, [FromServices] IEditMaintenanceCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
