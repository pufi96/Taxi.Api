using AutoMapper;
using System;
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
                config.CreateMap<Maintenance, MaintenanceDtoCar>();
                config.CreateMap<Car, CarDto>();
                config.CreateMap<Car, CreateCarDto>();
                config.CreateMap<CarModel, CreateCarModelDto>();
                config.CreateMap<Maintenance, EditMaintenanceDto>();

                config.CreateMap<Debtor, DebtorDtoDebt>()
                        .ForMember(dest => dest.Rides, opt => opt.MapFrom(src => src.InDebteds));
                config.CreateMap<InDebted, RideDto>()
                        .ForMember(dest => dest.IsLocal, opt => opt.MapFrom(src => src.Ride.IsLocal))
                        .ForMember(dest => dest.RidePrice, opt => opt.MapFrom(src => src.Ride.RidePrice))
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Ride.Id))
                        .ForMember(dest => dest.LocationPrice, opt => opt.MapFrom(src => src.Ride.LocationPrice));

                config.CreateMap<Ride, RideDtoDebtor>()
                        .ForMember(dest => dest.Debtor, opt => opt.MapFrom(src => src.InDebteds));
                config.CreateMap<InDebted, DebtorDto>()
                        .ForMember(dest => dest.DebtorFirstName, opt => opt.MapFrom(src => src.Debtor.DebtorFirstName))
                        .ForMember(dest => dest.DebtorLastName, opt => opt.MapFrom(src => src.Debtor.DebtorLastName))
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Debtor.Id))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Debtor.Description));

                config.CreateMap<LocationPrice, LocationPricesDto>()
                        .ForMember(dest => dest.LocationStart, opt => opt.MapFrom(src => src.LocationStart.LocationName))
                        .ForMember(dest => dest.LocationEnd, opt => opt.MapFrom(src => src.LocationEnd.LocationName));


                config.CreateMap<Car, CarDtoMaintenances>()
                        .ForMember(dest => dest.Maintenances, opt => opt.MapFrom(src => src.Maintenances))
                        .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.FuelType));

                config.ValidateInlineMaps = false;
                config.CreateMissingTypeMaps = true;
            });
        }
    }
}
