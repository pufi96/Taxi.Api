using System.Collections.Generic;

namespace Taxi.Domain.Entities
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
