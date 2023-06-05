using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCases.Commands.CarBrand;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarBrandController : ControllerBase
    {
        private UseCaseHandler _handler;

        public CarBrandController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<CarBrandController>
        [HttpGet]
        public IActionResult Get([FromQuery]BaseSearch search, [FromServices] IGetCarBrandsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // get api/<carbrandcontroller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCarBrandQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<CarBrandController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCarBrandDto request, [FromServices] ICreateCarBrandCommand command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<CarBrandController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CarBrandDto request, [FromServices] IEditCarBrandCommand command)
        {
            request.Id = id;
            _handler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }
}
