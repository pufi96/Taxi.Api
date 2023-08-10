using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Taxi.API.DTO;
using Taxi.Application.UseCaseHandling;
using Taxi.Application.UseCases.Commands.Car;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpg", ".png", ".jpeg", ".gif", ".JPG", ".JPEG", ".PNG", ".GIF" };

        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;
        private readonly IAzureStorage _storage;
        public CarController(IQueryHandler queryHandler, ICommandHandler commandHandler, IAzureStorage storage)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
            _storage = storage;
        }
        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BaseSearch search, [FromServices] IGetCarsQuery query)
        {
            List<BlobDto>? files = await _storage.ListAsync();

            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, [FromServices] IFindCarQuery query)
        {
            BlobFileDto response;
            var car = _queryHandler.HandleQuery(query, id);

            if (car.ImageFilePath != null)
            {
                response = await _storage.GetFileFromBlobStorage(car.ImageFilePath);
                car.Image = response;
            }

            return Ok(car);
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] RegisterImageApiDto request, [FromServices] ICreateCarCommand command, IFormFile file)
        {
            if(file != null)
            {
                request.Image = file;
                BlobResponseDto? response = await _storage.UploadAsync(request.Image);

                //var guid = Guid.NewGuid();
                //var extension = Path.GetExtension(request.Image.FileName);

                //if (!AllowedExtensions.Contains(extension))
                //{
                //    throw new InvalidOperationException("Unsupported file type.");
                //}

                //var fileName = guid + extension;

                //var filePath = Path.Combine("wwwroot", "images", fileName);

                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    request.Image.CopyTo(fileStream);
                //};
                request.ImageFilePath = response.Blob.Name;


                if(response.Error == true)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, response.Status);
                }

            }
            _commandHandler.HandleCommand(command, request);
            return StatusCode(201);
        }

        // PUT api/<CarController>/edit
        [HttpPut("edit")]
        public IActionResult Put([FromBody] CarDto request, [FromServices] IEditCarCommand command)
        {
            _commandHandler.HandleCommand(command, request);
            return StatusCode(204);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCarCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
