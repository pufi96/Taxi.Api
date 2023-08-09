using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCaseHandling;
using Taxi.Application.UseCases.Commands.DebtCollection;
using Taxi.Application.UseCases.Commands.Location;
using Taxi.Application.UseCases.DTO;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtCollectionController : ControllerBase
    {

        private ICommandHandler _commandHandler;

        public DebtCollectionController(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        // POST api/<DebtCollectionController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateDebtCollectionDto request, [FromServices] ICreateDebtCollectionCommand  command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<DebtCollectionController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] DebtCollectionDto request, [FromServices] IEditDebtCollectionCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
