using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using Taxi.Application.UseCases.Commands.Debtor;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DebtorController : ControllerBase
    {
        private UseCaseHandler _handler;

        public DebtorController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<DebtorController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetDebtorsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<DebtorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindDebtorQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<DebtorController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateDebtorDto request, [FromServices] ICreateDebtorCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<DebtorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DebtorDto request, [FromServices] IEditDebtorCommand command)
        {
            request.Id = id;
            _handler.HandleCommand(command, request);
            return StatusCode(204);
        }

    }
}
