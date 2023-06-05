using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.Application.UseCases.DTO
{
    public class MaintenanceTypeDto : BaseDto
    {
        public string MaintenanceTypeName { get; set; }
    }
}
