using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Application.UseCaseHandling;
using Taxi.Application.UseCases.Queries.MaintenacesType;
using Taxi.Application.UseCases.Queries.MaintenanceType;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaintenanceTypeController : ControllerBase
    {
        private IQueryHandler _queryHandler;

        public MaintenanceTypeController(IQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }

        // GET: api/<MaintenanceTypeController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetMaintenanceTypesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<MaintenanceTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindMaintenanceTypeQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }
    }
}
