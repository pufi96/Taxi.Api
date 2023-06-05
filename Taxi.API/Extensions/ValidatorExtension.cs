using Microsoft.Extensions.DependencyInjection;
using Taxi.Application.UseCases.Commands.CarModel;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.CarModel;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.Application.UseCases.Queries.Location;
using Taxi.Application.UseCases.Queries.LocationPrice;
using Taxi.Application.UseCases.Queries.MaintenacesType;
using Taxi.Application.UseCases.Queries.Maintenance;
using Taxi.Application.UseCases.Queries.MaintenanceType;
using Taxi.Application.UseCases.Queries.Ride;
using Taxi.Application.UseCases.Queries.Role;
using Taxi.Application.UseCases.Queries.User;
using Taxi.Application.UseCases;
using Taxi.Implementation.Logging;
using Taxi.Implementation.UseCases.Commands.EfCarModels;
using Taxi.Implementation.UseCases.Queries.EfCarBrands;
using Taxi.Implementation.UseCases.Queries.EfCarModel;
using Taxi.Implementation.UseCases.Queries.EfCars;
using Taxi.Implementation.UseCases.Queries.EfDebtors;
using Taxi.Implementation.UseCases.Queries.EfFuelTypes;
using Taxi.Implementation.UseCases.Queries.EfMaintenances;
using Taxi.Implementation.UseCases.Queries.LocationPrices;
using Taxi.Implementation.UseCases.Queries.Locations;
using Taxi.Implementation.UseCases.Queries.MaintenancesTypes;
using Taxi.Implementation.UseCases.Queries.Rides;
using Taxi.Implementation.UseCases.Queries.Roles;
using Taxi.Implementation.UseCases.Queries.Users;
using Taxi.Implementation.Validators;

namespace Taxi.API.Extensions
{
    public static class ValidatorExtension
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateCarBrandValidator>();
            services.AddTransient<CreateCarModelValidator>();
            services.AddTransient<CreateCarValidator>();
            services.AddTransient<CreateDebtCollectionValidator>();
            services.AddTransient<CreateDebtorValidator>();
            services.AddTransient<CreateLocationPriceValidator>();
            services.AddTransient<CreateLocationValidator>();
            services.AddTransient<CreateMaintenanceValidator>();
            services.AddTransient<CreateRideValidator>();
            services.AddTransient<CreateShiftValidator>();
            services.AddTransient<CreateUserValidator>();

            services.AddTransient<EditCarBrandValidator>();
            services.AddTransient<EditCarModelValidator>();
            services.AddTransient<EditCarValidator>();
            services.AddTransient<EditDebtCollectionValidator>();
            services.AddTransient<EditDebtorValidator>();
            services.AddTransient<EditLocationPriceValidator>();
            services.AddTransient<EditLocationValidator>();
            services.AddTransient<EditMaintenanceValidator>();
            services.AddTransient<EditRideValidator>();
            services.AddTransient<EditShiftValidator>();
            services.AddTransient<EditUserValidator>();
        }
    }
}
