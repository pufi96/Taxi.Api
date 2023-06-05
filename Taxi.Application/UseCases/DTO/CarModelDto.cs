using Taxi.Application.UseCases.DTO;

namespace Taxi.Application.UseCases.DTO
{
    public class CarModelDto : BaseDto
    {
        public string CarModelName { get; set; }
        public CarBrandDto CarBrand { get; set; }
    }
    public class CreateCarModelDto
    {
        public string CarModelName { get; set; }
        public CarBrandDto CarBrand { get; set; }
    }
}
