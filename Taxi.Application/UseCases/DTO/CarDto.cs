using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.Application.UseCases.DTO
{
    public class CarDto : BaseDto
    {
        public string Registration { get; set; }
        public DateTime ValidityOfRegistration { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string ChassisNumber { get; set; }
        public double EngineVolume { get; set; }
        public int HorsePower { get; set; }
        public string ImageFilePath { get; set; }
        public BlobFileDto? Image { get; set; } 
        public int FuelTypeId { get; set; }
        public int CarModelId { get; set; }
    }

    public class CreateCarDto 
    {
        public string Registration { get; set; }
        public DateTime ValidityOfRegistration { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string ChassisNumber { get; set; }
        public double EngineVolume { get; set; }
        public int HorsePower { get; set; }
        public string ImageFilePath { get; set; }
        public int FuelTypeId { get; set; }
        public int CarModelId { get; set; }
    }
}
