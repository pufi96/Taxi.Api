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
        public IEnumerable<DebtorDto> Debtors { get; set; }
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
    public class CreateRideDto
    {
        public bool IsLocal { get; set; }
        public double RidePrice { get; set; }
        public LocationPricesDto LocationPrice { get; set; }
        public ShiftDto Shift { get; set; }
        public DebtorDto Debtors { get; set; }
    }
}
