using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases.DTO
{
    public class FuelTypeDto : BaseDto
    {
        public string FuelTypeName { get; set; }
    }
    public class CreateFuelTypeDto
    {
        public string FuelTypeName { get; set; }
    }
}
