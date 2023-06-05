using System;
using System.Collections;
using System.Collections.Generic;

namespace Taxi.Application.UseCases.DTO
{
    public class ShiftDto : BaseDto
    {
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public int MileageStart { get; set; }
        public int MileageEnd { get; set; }
        public double Turnover { get; set; }
        public double Earnings { get; set; }
        public double Expenses { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public IEnumerable<RideDto> Rides { get; set; }
    }
    public class CreateShiftDto
    {
        public DateTime ShiftStart { get; set; }
        public DateTime? ShiftEnd { get; set; }
        public int MileageStart { get; set; }
        public int? MileageEnd { get; set; }
        public double? Turnover { get; set; }
        public double? Earnings { get; set; }
        public double? Expenses { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public IEnumerable<RideDto> Rides { get; set; }
    }

   
   
}
