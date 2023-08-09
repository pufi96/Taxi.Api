using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCaseHandling;
using Taxi.Application.UseCases.Commands.Shift;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.Implementation;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShiftController : ControllerBase
    {
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public ShiftController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<ShiftController>
        [HttpGet]
        public IActionResult Get([FromQuery] ShiftSearch search, [FromServices] IGetShiftsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        [HttpGet("find-unfinished/{id}")]
        public IActionResult FindUnfinished(int id, [FromServices] IFindUnfinishedShiftQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        [HttpGet("find-user-shifts/{id}")]
        public IActionResult FindUserShifts(int id, [FromServices] IGetUserShifts query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }


        // GET api/<ShiftController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindShiftQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<ShiftController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateShiftDto request, [FromServices] ICreateShiftCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<ShiftController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] ShiftDto request, [FromServices] IEditShiftCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
