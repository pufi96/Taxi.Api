using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases.DTO
{
    public class LocationPricesDto : BaseDto
    {
        public string LocationStart { get; set; }
        public string LocationEnd { get; set; }
        public double Price { get; set; }
    }
    public class CreateLocationPricesDto
    {
        public int LocationStartId { get; set; }
        public int LocationEndId { get; set; }
        public double Price { get; set; }
    }
}
