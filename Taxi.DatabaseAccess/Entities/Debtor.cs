using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DatabaseAccess.Entities
{
    public class Debtor : Entity
    {
        public string DebtorFirstName { get; set; }
        public string DebtorLastName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<InDebted> InDebteds { get; set; } = new HashSet<InDebted>();
        public virtual ICollection<DebtCollection> DebtCollections { get; set; } = new HashSet<DebtCollection>();
    }
}
