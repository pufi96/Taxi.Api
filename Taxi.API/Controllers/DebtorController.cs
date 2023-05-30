using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult Get(int id, [FromServices] IFindDebtorsQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<DebtorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DebtorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DebtorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
