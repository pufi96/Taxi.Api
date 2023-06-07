using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.Application.UseCases.DTO
{
    public class RideDtoDebtor : BaseDto
    {
        public bool IsLocal { get; set; }
        public double RidePrice { get; set; }
        public LocationPricesDto LocationPrice { get; set; }
        public DebtorDto Debtor { get; set; }
    }
    public class RideDto : BaseDto
    {
        public bool IsLocal { get; set; }
        public double RidePrice { get; set; }
        public LocationPricesDto LocationPrice { get; set; }
    }
    public class RideDtoShift : RideDto
    {
        public ShiftDtoUser Shift { get; set; }
    }
    public class EditRideDto : BaseDto
    {
        public bool IsLocal { get; set; }
        public double RidePrice { get; set; }
        public int? LocationPriceId { get; set; }
        public int ShiftId { get; set; }
        public int? DebtorId { get; set; }
    }
    public class CreateRideDto
    {
        public bool IsLocal { get; set; }
        public double RidePrice { get; set; }
        public int? LocationPriceId { get; set; }
        public int ShiftId { get; set; }
        public int? DebtorId { get; set; }
    }
}
