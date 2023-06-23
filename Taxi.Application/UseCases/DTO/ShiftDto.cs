using System;
using System.Collections;
using System.Collections.Generic;
using Taxi.Domain.Entities;

namespace Taxi.Application.UseCases.DTO
{
    
    public class ShiftDto : BaseDto
    {
        public bool IsActive { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public int MileageStart { get; set; }
        public int MileageEnd { get; set; }
        public double Turnover { get; set; }
        public double Earnings { get; set; }
        public double Expenses { get; set; }
        public CarDto Car { get; set; }
    }
    public class ShiftDtoUserRides : ShiftDto
    {
        public UserDto User { get; set; }
        public IEnumerable<RideDtoDebtor> Rides { get; set; }
    }
    public class ShiftDtoUser : ShiftDto
    {
        public UserDto User { get; set; }
    }
    public class ShiftDtoRide : ShiftDto
    {
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
        public UserDto User { get; set; }
        public CarDto Car { get; set; }
    }

   
   
}
