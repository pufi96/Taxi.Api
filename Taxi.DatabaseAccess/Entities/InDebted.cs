using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DatabaseAccess.Entities
{
    public class InDebted
    {
        public int DebtorId { get; set; }
        public int RideId { get; set; }

        public virtual Debtor Debtor { get; set; }
        public virtual Ride Ride { get; set; }
        
    }
}
