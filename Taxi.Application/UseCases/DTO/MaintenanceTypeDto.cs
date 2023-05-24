using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases.DTO
{
    public class MaintenanceTypeDto : BaseDto
    {
        public string MaintenanceTypeName { get; set; }
    }
    public class CreateMaintenanceTypeDto
    {
        public string MaintenanceTypeName { get; set; }
    }
}
