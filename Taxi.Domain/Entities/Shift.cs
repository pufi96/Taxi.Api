using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class Shift : Entity
    {
        public DateTime ShiftStart { get; set; }
        public DateTime? ShiftEnd { get; set; }
        public int MileageStart { get; set; }
        public int? MileageEnd { get; set; }
        public double? Turnover { get; set; }
        public double? Earnings { get; set; }
        public double? Expenses { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }

        public virtual ICollection<Ride> Rides{ get; set; } = new HashSet<Ride>();
        public virtual User User { get; set; }
        public virtual Car Car { get; set; }
        

    }
}
