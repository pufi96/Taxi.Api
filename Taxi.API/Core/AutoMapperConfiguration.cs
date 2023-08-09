using AutoMapper;
using System;
using System.Linq;
using Taxi.API.DTO;
using Taxi.Application.UseCases.DTO;
using Taxi.Domain.Entities;

namespace Taxi.API.Core
{
    public static class AutoMapperConfiguration
    {
        [Obsolete]
        public static void InitAutoMapper()
        {
            Mapper.Initialize(config =>
            {

                config.CreateMap<MaintenanceType, MaintenanceTypeDto>();
                config.CreateMap<Maintenance, MaintenanceDto>();
                config.CreateMap<Car, CarDto>();
                config.CreateMap<Car, CreateCarDto>();
                config.CreateMap<CarModel, CreateCarModelDto>();
                config.CreateMap<Maintenance, MaintenanceDto>();

                config.CreateMap<LogEntry, LogDto>();

                config.CreateMap<LocationPrice, LocationPricesDto>()
                        .ForMember(dest => dest.LocationStart, opt => opt.MapFrom(src => src.LocationStart.LocationName))
                        .ForMember(dest => dest.LocationEnd, opt => opt.MapFrom(src => src.LocationEnd.LocationName));

                config.CreateMap<LocationPrice, LocationPricesDto>()
                        .ForMember(dest => dest.LocationStart, opt => opt.MapFrom(src => src.LocationStart.LocationName))
                        .ForMember(dest => dest.LocationEnd, opt => opt.MapFrom(src => src.LocationEnd.LocationName));

                config.CreateMap<Car, CarDto>()
                        .ForMember(dest => dest.FuelTypeId, opt => opt.MapFrom(src => src.FuelType));

                config.ValidateInlineMaps = false;
                config.CreateMissingTypeMaps = true;
            });
        }
    }
}
