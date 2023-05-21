using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class DebtCollection : Entity
    {
        public double DebtCollectionPrice { get; set; }
        public int DebtorId { get; set; }

        public virtual Debtor Debtor { get; set; }
    }
}
