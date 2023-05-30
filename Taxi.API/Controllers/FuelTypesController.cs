using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCases.Queries.CarModel;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public FuelTypesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<FuelTypesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetFuelTypesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<FuelTypesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindFuelTypesQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<FuelTypesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FuelTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FuelTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
