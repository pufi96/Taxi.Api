using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class Location : Entity
    {
        public string LocationName { get; set; }

        public virtual ICollection<LocationPrice> LocationPricesStart { get; set;} = new HashSet<LocationPrice>();
        public virtual ICollection<LocationPrice> LocationPricesEnd { get; set;} = new HashSet<LocationPrice>();
    }
}
