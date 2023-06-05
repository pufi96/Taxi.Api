using System.Collections.Generic;
using Taxi.Application.UseCases.DTO;
using Taxi.Domain.Entities;

namespace Taxi.Application.UseCases.DTO
{
    public class CarBrandDto : BaseDto
    {
        public string CarBrandName { get; set; }
        public IEnumerable<CarModel> CarModels { get; set; }
    }
    public class CreateCarBrandDto
    {
        public string CarBrandName { get; set; }
        public IEnumerable<CarModel> CarModels { get; set; }
    }

}
