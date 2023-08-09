using System.Collections.Generic;

namespace Taxi.Domain.Entities
{
    public class Debtor : Entity
    {
        public string DebtorFirstName { get; set; }
        public string DebtorLastName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ride> Rides { get; set; } = new HashSet<Ride>();
        public virtual ICollection<DebtCollection> DebtCollections { get; set; } = new HashSet<DebtCollection>();
    }
}
