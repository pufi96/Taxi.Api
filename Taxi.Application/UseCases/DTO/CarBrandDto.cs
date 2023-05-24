using Taxi.Application.UseCases.DTO;

namespace Taxi.Application.UseCases.DTO
{
    public class CarBrandDto : BaseDto
    {
        public string CarBrandName { get; set; }
    }
    public class CreateCarBrandDto
    {
        public string CarBrandName { get; set; }
    }

}
