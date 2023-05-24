using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases.DTO
{
    public class DebtorDto : BaseDto
    {
        public string DebtorFirstName { get; set; }
        public string DebtorLastName { get; set; }
        public string Description { get; set; }
        public IEnumerable<DebtCollectionsDto> DebtCollections { get; set; }
        public IEnumerable<RideDto> Rides { get; set; }
    }
    public class DebtCollectionsDto : DebtCollectionDto
    {
        public DateTime CreatedAt { get; set; }
    }
    

    public class CreateDebtDto
    {
        public string DebtorFirstName { get; set; }
        public string DebtorLastName { get; set; }
        public string Description { get; set; }
    }
}
