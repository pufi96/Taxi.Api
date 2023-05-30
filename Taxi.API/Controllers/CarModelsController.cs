using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.API.DTO;
using Taxi.API.ErrorLogging;
using Taxi.API.Vaidators;
using Taxi.Application.UseCases.Queries.CarModel;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using Taxi.Implementation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : BaseController
    {
        private UseCaseHandler _handler;

        public CarModelsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        // GET: api/<CarModelController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCarModelsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<CarModelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCarModelsQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        //// POST api/<CarModelController>
        //[HttpPost]
        //public IActionResult Post([FromBody] CreateCarModelDto dto, [FromServices] CreateCarModelValidator validator)
        //{
        //    try
        //    {
        //        var result = validator.Validate(dto);

        //        if (!result.IsValid)
        //        {
        //            return result.ToUnprocessableEntity();
        //        }

        //        _context.CarModels.Add(new CarModel
        //        {
        //            CarModelName = dto.CarModelName,
        //            CarBrandId = dto.CarBrandId
        //        });

        //        _context.SaveChanges();

        //        return StatusCode(201);
        //    }

        //    catch (Exception ex)
        //    {
        //        return Error(ex);
        //    }
        //}

        //// PUT api/<CarModelController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] CreateCarModelDto dto)
        //{
        //    try
        //    {
        //        var carModel = _context.CarModels.Find(id);
        //        if (carModel == null || carModel.IsActive)
        //        {
        //            return NotFound();
        //        }

        //        carModel.CarModelName = dto.CarModelName;
        //        carModel.CarBrandId = dto.CarBrandId;
        //        carModel.EditedAt = DateTime.UtcNow;

        //        _context.SaveChanges();

        //        return StatusCode(204);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Error(ex);
        //    }
        //}

        //// DELETE api/<CarModelController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var carModel = _context.CarModels.Find(id);

        //        if(carModel == null || !carModel.IsActive)
        //        {
        //            return NotFound();
        //        }

        //        carModel.IsActive = false;
        //        carModel.DeletedAt = DateTime.UtcNow;

        //        _context.SaveChanges();

        //        return NoContent();
        //    }

        //    catch (Exception ex)
        //    {
        //        return Error(ex);
        //    }
        //}
    }
}
