using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Taxi.API.DTO;
using Taxi.API.ErrorLogging;
using Taxi.API.Vaidators;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using Taxi.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandsController : BaseController
    {
        private UseCaseHandler _handler;

        public CarBrandsController(UseCaseHandler handler)
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
        public IActionResult Get(int id, [FromServices] IFindCarBrandsQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        ////// POST api/<CarBrandController>
        ////[HttpPost]
        ////public IActionResult Post([FromBody] CarBrandDto dto , [FromServices] CreateCarBrandValidator validator)
        ////{
        ////    try
        ////    {
        ////        var result = validator.Validate(dto);

        ////        if (!result.IsValid)
        ////        {
        ////            return result.ToUnprocessableEntity();
        ////        }

        ////        _context.CarBrands.Add(new CarBrand
        ////        {
        ////            CarBrandName = dto.CarBrandName
        ////        });

        ////        _context.SaveChanges();

        ////        return StatusCode(201);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return Error(ex);
        ////    }
        ////}

        ////// PUT api/<CarBrandController>/5
        ////[HttpPut("{id}")]
        ////public IActionResult Put(int id, [FromBody] CreateCarBrandDto dto)
        ////{
        ////    try
        ////    {
        ////        var carBrand = _context.CarBrands.Find(id);
        ////        if (carBrand == null || carBrand.IsActive)
        ////        {
        ////            return NotFound();
        ////        }

        ////        carBrand.CarBrandName = dto.CarBrandName;
        ////        carBrand.EditedAt = DateTime.UtcNow;

        ////        _context.SaveChanges();

        ////        return StatusCode(204);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return Error(ex);
        ////    }
        ////}

        ////// DELETE api/<CarBrandController>/5
        ////[HttpDelete("{id}")]
        ////public IActionResult Delete(int id)
        ////{
        ////    try
        ////    {
        ////        var carBrand = _context.CarBrands.Find(id);
        ////        if(carBrand == null || carBrand.IsActive)
        ////        {
        ////            return NotFound();
        ////        }

        ////        carBrand.IsActive = false;
        ////        carBrand.DeletedAt = DateTime.UtcNow;

        ////        _context.SaveChanges();

        ////        return NoContent();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return Error(ex);
        ////    }
        ////}
    }
}
