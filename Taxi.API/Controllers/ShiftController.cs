using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private UseCaseHandler _handler;

        public ShiftController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<ShiftController>
        [HttpGet]
        public IActionResult Get([FromQuery] ShiftSearch search, [FromServices] IGetShiftsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<ShiftController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindShiftQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<ShiftController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateShiftDto request, [FromServices] ICreateShiftCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<ShiftController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ShiftDto request, [FromServices] IEditShiftCommand command)
        {
            request.Id = id;
            _handler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
