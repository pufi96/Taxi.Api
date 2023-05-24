using AutoMapper;
using System;
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
                config.CreateMap<Debtor, DebtorDto>()
                        .ForMember(dest => dest.Rides, opt => opt.MapFrom(src => src.InDebteds));

                config.CreateMap<InDebted, RideDto>()
                        .ForMember(dest => dest.IsLocal, opt => opt.MapFrom(src => src.Ride.IsLocal))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Ride.RidePrice))
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Ride.Id))
                        .ForMember(dest => dest.LocationPrice, opt => opt.MapFrom(src => src.Ride.LocationPrice));

                config.CreateMap<LocationPrice, LocationPricesDto>()
                        .ForMember(dest => dest.LocationStart, opt => opt.MapFrom(src => src.LocationStart.LocationName))
                        .ForMember(dest => dest.LocationEnd, opt => opt.MapFrom(src => src.LocationEnd.LocationName));


                config.ValidateInlineMaps = false;
                config.CreateMissingTypeMaps = true;
            });
        }
    }
}
