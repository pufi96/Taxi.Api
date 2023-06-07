using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCases.Commands.User;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Application.UseCases.Queries.User;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private UseCaseHandler _handler;

        public UserController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindUserQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto request, [FromServices] ICreateUserCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<UserController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] UserDto request, [FromServices] IEditUserCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(204);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
