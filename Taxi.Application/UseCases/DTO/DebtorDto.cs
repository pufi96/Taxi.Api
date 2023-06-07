using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.Application.UseCases.DTO
{
    public class DebtorDtoDebt : DebtorDto
    {
        public IEnumerable<DebtCollectionDto> DebtCollections { get; set; }
        public IEnumerable<RideDto> Rides { get; set; }
    }
    public class DebtorDto : BaseDto
    {
        public string DebtorFirstName { get; set; }
        public string DebtorLastName { get; set; }
        public string Description { get; set; }
    }
    public class CreateDebtorDto
    {
        public string DebtorFirstName { get; set; }
        public string DebtorLastName { get; set; }
        public string Description { get; set; }
    }
}
