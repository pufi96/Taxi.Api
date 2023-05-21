using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class Car : Entity
    {
        public string Registration { get; set; }
        public DateTime ValidityOfRegistration { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int ChassisNumber { get; set; }
        public double EngineVolume { get; set; }
        public int HorsePower { get; set; }
        public string FuelType { get; set; }
        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }
    }
}
