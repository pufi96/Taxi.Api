using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Taxi.API.DTO;
using Taxi.API.ErrorLogging;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;
using Taxi.Implementation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : BaseController
    {
        private UseCaseHandler _handler;

        public ShiftController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetDebtorsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        // GET: api/<ShiftController>
        //[HttpGet]
        //public IActionResult Get([FromQuery] ShiftSearch search)
        //{
        //    try
        //    {
        //        var query = _context.Shifts
        //                        .Include(x => x.User)
        //                        .Where(x => x.IsActive && x.DeletedAt == null)
        //                        .Include(x => x.Rides)
        //                        .ThenInclude(x=>x.LocationPrice)
        //                        .Where(x => x.IsActive && x.DeletedAt == null);
        //        if (!string.IsNullOrEmpty(search.Username)){
        //            query = query.Where(x => x.User.Username.ToLower() == search.Username.ToLower());
        //        }
        //        if (search.DateFrom.HasValue){
        //            query = query.Where(x => x.CreatedAt >= search.DateFrom.Value);
        //        }
        //        if (search.DateTo.HasValue){
        //            query = query.Where(x => x.EditedAt >= search.DateTo.Value);
        //        }
        //       // query = query.Where(x => x.EditedAt.HasValue);
        //        IEnumerable<ShiftDto> result = query.Select(x => new ShiftDto
        //        {   
        //            Id = x.Id,
        //            FirstName = x.User.FirstName,
        //            LastName = x.User.LastName,
        //            ShiftDate = x.CreatedAt.ToString("yyyy-MM-dd hh:mm:ss"),
        //            MileageStart = x.MileageStart,
        //            MileageEnd = x.MileageEnd == null ? 0: (int)x.MileageEnd,
        //            Turnover = x.Turnover == null ? 0 : (int)x.Turnover,
        //            Earnings = x.Earnings == null ? 0 :  (int)x.Earnings,
        //            Expenses = x.Expenses == null ? 0 :  (int)x.Expenses,
        //            Rides = x.Rides.Select(z => new RideDto
        //            {
        //                Id = z.Id,
        //                IsLocal = z.IsLocal,
        //                Price = z.Price,
        //                LocationPrice = new LocationPricesDto
        //                {
        //                    Id = z.LocationPrice.Id,
        //                    LocationStart = z.LocationPrice.LocationStart.LocationName,
        //                    LocationEnd = z.LocationPrice.LocationEnd.LocationName
        //                }
        //            })
        //        }).ToList();
        //    return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Error(ex);
        //    }
        //}

        //// GET api/<ShiftController>/5
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        var query = _context.Shifts
        //                        .Include(x => x.User)
        //                        .Where(x => x.IsActive && x.DeletedAt == null)
        //                        .Include(x => x.Rides)
        //                        .ThenInclude(x => x.LocationPrice)
        //                        .Where(x => x.IsActive && x.DeletedAt == null);
        //        IEnumerable<ShiftDto> result = query.Where(x => x.Id == id).Select(x => new ShiftDto
        //        {
        //            Id = x.Id,
        //            FirstName = x.User.FirstName,
        //            LastName = x.User.LastName,
        //            ShiftDate = x.CreatedAt.ToString("yyyy-MM-dd hh:mm:ss"),
        //            MileageStart = x.MileageStart,
        //            MileageEnd = x.MileageEnd == null ? 0 : (int)x.MileageEnd,
        //            Turnover = x.Turnover == null ? 0 : (int)x.Turnover,
        //            Earnings = x.Earnings == null ? 0 : (int)x.Earnings,
        //            Expenses = x.Expenses == null ? 0 : (int)x.Expenses,
        //            Rides = x.Rides.Select(z => new RideDto
        //            {
        //                Id = z.Id,
        //                IsLocal = z.IsLocal,
        //                Price = z.Price,
        //                LocationPrice = new LocationPricesDto
        //                {
        //                    Id = z.LocationPrice.Id,
        //                    LocationStart = z.LocationPrice.LocationStart.LocationName,
        //                    LocationEnd = z.LocationPrice.LocationEnd.LocationName
        //                }
        //            })
        //        }).ToList();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Error(ex);
        //    }
        //}

        // POST api/<ShiftController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShiftController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShiftController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
