using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class Maintenance : Entity
    {
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? Price { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public int MaintenaceTypeId { get; set; }
        public int CarId { get; set; }

        public virtual MaintenanceType MaintenanceType { get; set; }
        public virtual Car Car { get; set; }
    }
}
