using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;

namespace Taxi.Application.UseCases.Queries.Searches
{
    public class CarSearch
    {
        public string CarModelName { get; set; }
        public string CarBrandName { get; set; }
        public string MaintenanceTypeName { get; set; }
    }
}
