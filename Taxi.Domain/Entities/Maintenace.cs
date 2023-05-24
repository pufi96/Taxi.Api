using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class Maintenace : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Price { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public int MaintenaceTypeId { get; set; }
        public int CarId { get; set; }

        public virtual MaintenanceType MaintenaceType { get; set; }
        public virtual Car Car { get; set; }
    }
}
