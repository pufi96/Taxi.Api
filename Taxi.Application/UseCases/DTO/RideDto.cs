using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases.DTO
{
    public class RideDto : BaseDto
    {
        public bool IsLocal { get; set; }
        public double Price { get; set; }
        public LocationPricesDto LocationPrice { get; set; }
    }
    public class CreateRideDto
    {
        public bool IsLocal { get; set; }
        public double Price { get; set; }
        public LocationPricesDto LocationPrice { get; set; }
    }
}
