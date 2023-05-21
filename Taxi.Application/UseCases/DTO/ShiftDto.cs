using System;
using System.Collections;
using System.Collections.Generic;

namespace Taxi.Application.UseCases.DTO
{
    public class ShiftDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShiftDate { get; set; }
        public int MileageStart { get; set; }
        public int MileageEnd { get; set; }
        public double Turnover { get; set; }
        public double Earnings { get; set; }
        public double Expenses { get; set; }
        public IEnumerable<RideDto> Rides { get; set; }
    }

    public class RideDto
    {
        public int Id { get; set; }
        public bool IsLocal { get; set; }
        public double Price { get; set; }
        public LocationPricesDto LocationPrice { get; set; }
    }
    public class LocationPricesDto
    {
        public int Id { get; set; }
        public string LocationStart { get; set; }
        public string LocationEnd { get; set; }
    }
}
