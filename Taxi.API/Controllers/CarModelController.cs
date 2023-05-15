using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.API.DTO;
using Taxi.API.ErrorLogging;
using Taxi.API.Vaidators;
using Taxi.DatabaseAccess;
using Taxi.DatabaseAccess.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : BaseController
    {
        TaxiContext _context;

        public CarModelController(TaxiContext context, IErrorLogger logger)
            : base(logger)
        {
            _context = context;
        }
    
        // GET: api/<CarModelController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var query = _context.CarModels
                                    .Include(x => x.CarBrand);

                IEnumerable<CarModelDto> result = query.Select(x => new CarModelDto
                {
                    Id = x.Id,
                    CarModelName = x.CarModelName,
                    CarBrandId = x.CarBrandId
                }).ToList();

                return Ok(result);
            }

            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        // GET api/<CarModelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var query = _context.CarModels
                                    .Include(x => x.CarBrand);

                IEnumerable<CarModelDto> result = query.Where(x => x.Id == id).Select(x => new CarModelDto
                {
                    Id = x.Id,
                    CarModelName = x.CarModelName,
                    CarBrandId = x.CarBrandId
                }).ToList();

                return Ok(result);
            }

            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        // POST api/<CarModelController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCarModelDto dto, [FromServices] CreateCarModelValidator validator)
        {
            try
            {
                var result = validator.Validate(dto);

                if (!result.IsValid)
                {
                    return result.ToUnprocessableEntity();
                }

                _context.CarModels.Add(new CarModel
                {
                    CarModelName = dto.CarModelName,
                    CarBrandId = dto.CarBrandId
                });

                _context.SaveChanges();

                return StatusCode(201);
            }

            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        // PUT api/<CarModelController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateCarModelDto dto)
        {
            try
            {
                var carModel = _context.CarModels.Find(id);
                if (carModel == null || carModel.IsActive)
                {
                    return NotFound();
                }

                carModel.CarModelName = dto.CarModelName;
                carModel.CarBrandId = dto.CarBrandId;
                carModel.EditedAt = DateTime.UtcNow;

                _context.SaveChanges();

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        // DELETE api/<CarModelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var carModel = _context.CarModels.Find(id);

                if(carModel == null || !carModel.IsActive)
                {
                    return NotFound();
                }

                carModel.IsActive = false;
                carModel.DeletedAt = DateTime.UtcNow;

                _context.SaveChanges();

                return NoContent();
            }

            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
