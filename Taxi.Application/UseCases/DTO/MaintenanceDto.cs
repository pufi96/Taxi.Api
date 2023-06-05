using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases.DTO
{
    public class MaintenanceDto : BaseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Price { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public int MaintenanceTypeId { get; set; }
        public int CarId { get; set; }
    }
    public class CreateMaintenanceDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Price { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public int MaintenanceTypeId { get; set; }
        public int CarId { get; set; }
    }
}
