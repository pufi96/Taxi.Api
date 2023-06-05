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
        public string ChassisNumber { get; set; }
        public double EngineVolume { get; set; }
        public int HorsePower { get; set; }
        public int FuelTypeId { get; set; }
        public string ImageFilePath{ get; set; }
        public int CarModelId { get; set; }

        public virtual FuelType FuelType { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; } = new HashSet<Maintenance>();
        public virtual ICollection<Shift> Shifts { get; set; } = new HashSet<Shift>();
    }
}
