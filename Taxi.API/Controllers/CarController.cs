using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private UseCaseHandler _handler;

        public CarController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<CarController>
        [HttpGet]
        public IActionResult Get([FromQuery] CarSearch search, [FromServices] IGetCarsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCarsQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
