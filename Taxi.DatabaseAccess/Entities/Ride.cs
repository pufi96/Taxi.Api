using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DatabaseAccess.Entities
{
    public class Ride : Entity
    {
        public bool IsLocal { get; set; }
        public double Price { get; set; }
        public int? LocationPriceId { get; set; }
        
        public virtual LocationPrice LocationPrice { get; set; }
        public virtual ICollection<InDebted> InDebteds { get; set; } = new HashSet<InDebted>();
    }
}
