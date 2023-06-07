using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.Application.UseCases.DTO
{
    public class DebtCollectionDto : BaseDto
    {
        public double DebtCollectionPrice { get; set; }
    }
    public class DebtCollectionDtoDebtor : DebtCollectionDto
    {
        public DebtorDto Debtor { get; set; }
    }
    public class EditDebtCollectionDto : DebtCollectionDto
    {
        public int DebtorId { get; set; }
    }
    public class CreateDebtCollectionDto
    {
        public double DebtCollectionPrice { get; set; }
        public int DebtorId { get; set; }
    }
}
