using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class FuelType : Entity
    {
        public string FuelTypeName { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }  = new HashSet<Car>();

    }
}
