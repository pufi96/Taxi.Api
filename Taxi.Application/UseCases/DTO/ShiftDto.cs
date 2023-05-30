using System;
using System.Collections;
using System.Collections.Generic;

namespace Taxi.Application.UseCases.DTO
{
    public class ShiftDto : BaseDto
    {
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
    public class CreateShiftDto
    {
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

   
   
}
