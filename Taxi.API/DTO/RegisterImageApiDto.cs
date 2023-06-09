using Microsoft.AspNetCore.Http;
using Taxi.Application.UseCases.DTO;

namespace Taxi.API.DTO
{
    public class RegisterImageApiDto : CreateCarDto
    {
        public IFormFile Image { get; set; }
    }
}
