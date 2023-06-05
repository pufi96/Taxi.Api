using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.Application.UseCases.DTO
{
    public class FuelTypeDto : BaseDto
    {
        public string FuelTypeName { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
