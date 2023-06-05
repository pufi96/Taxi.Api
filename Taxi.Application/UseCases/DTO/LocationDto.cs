using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.Application.UseCases.DTO
{
    public class LocationDto : BaseDto
    {
        public string LocationName { get; set; }
    }
    public class CreateLocationDto
    {
        public string LocationName { get; set; }
    }
}
