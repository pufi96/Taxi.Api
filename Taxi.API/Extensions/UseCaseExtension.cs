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
using Taxi.Application.UseCases.Queries.User;
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
using Taxi.Implementation.UseCases.Queries.Users;
using Taxi.Implementation;
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.Implementation.UseCases.Queries.Shifts;
using Taxi.Application.UseCases.Commands.CarBrand;
using Taxi.Implementation.UseCases.Commands.EfCarBrands;
using Taxi.Application.UseCases.Commands.Car;
using Taxi.Implementation.UseCases.Commands.EfCars;
using Taxi.Application.UseCases.Commands.DebtCollection;
using Taxi.Implementation.UseCases.Commands.EfDebtCollection;
using Taxi.Application.UseCases.Commands.Debtor;
using Taxi.Implementation.UseCases.Commands.EfDebtors;
using Taxi.Application.UseCases.Commands.LocationPrice;
using Taxi.Implementation.UseCases.Commands.EfLocationPrices;
using Taxi.Application.UseCases.Commands.Location;
using Taxi.Implementation.UseCases.Commands.EfLocations;
using Taxi.Application.UseCases.Commands.Maintenance;
using Taxi.Implementation.UseCases.Commands.EfMaintenances;
using Taxi.Application.UseCases.Commands.Ride;
using Taxi.Implementation.UseCases.Commands.EfRides;
using Taxi.Application.UseCases.Commands.Shift;
using Taxi.Implementation.UseCases.Commands.EfShifts;
using Taxi.Application.UseCases.Commands.User;
using Taxi.Implementation.UseCases.Commands.EfUsers;
using Taxi.Application.Logging;
using Taxi.Application.UseCaseHandling;

namespace Taxi.API.Extensions
{
    public static class UseCaseExtension
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();


            //query

            services.AddTransient<IGetCarBrandsQuery, EfGetCarBrandsQuery>();
            services.AddTransient<IFindCarBrandQuery, EfFindCarBrandQuery>();

            services.AddTransient<IGetCarModelsQuery, EfGetCarModelsQuery>();
            services.AddTransient<IFindCarModelQuery, EfFindCarModelQuery>();

            services.AddTransient<IGetCarsQuery, EfGetCarsQuery>();
            services.AddTransient<IFindCarQuery, EfFindCarQuery>();

            services.AddTransient<IGetDebtorsQuery, EfGetDebtorsQuery>();
            services.AddTransient<IFindDebtorQuery, EfFindDebtorQuery>();

            services.AddTransient<IGetFuelTypesQuery, EfGetFuelTypesQuery>();
            services.AddTransient<IFindFuelTypeQuery, EfFindFuelTypeQuery>();

            services.AddTransient<IGetMaintenancesQuery, EfGetMaintenancesQuery>();
            services.AddTransient<IFindMaintenanceQuery, EfFindMaintenanceQuery>();

            services.AddTransient<IGetLocationPricesQuery, EfGetLocationPricesQuery>();
            services.AddTransient<IFindLocationPriceQuery, EfFindLocationPriceQuery>();

            services.AddTransient<IGetLocationsQuery, EfGetLocationsQuery>();
            services.AddTransient<IFindLocationQuery, EfFindLocationsQuery>();

            services.AddTransient<IGetMaintenanceTypesQuery, EfGetMaintenanceTypesQuery>();
            services.AddTransient<IFindMaintenanceTypeQuery, EfFindMaintenanceTypeQuery>();

            services.AddTransient<IGetRidesQuery, EfGetRidesQuery>();
            services.AddTransient<IFindRideQuery, EfFindRideQuery>();

            services.AddTransient<IGetShiftsQuery, EfGetShiftsQuery>();
            services.AddTransient<IFindShiftQuery, EfFindShiftsQuery>();

            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IFindUserQuery, EfFindUserQuery>();


            //command

            services.AddTransient<ICreateCarBrandCommand, EfCreateCarBrandCommand>();
            services.AddTransient<IEditCarBrandCommand, EfEditCarBrandCommand>();

            services.AddTransient<ICreateCarModelCommand, EfCreateCarModelCommand>();
            services.AddTransient<IEditCarModelCommand, EfEditCarModelCommand>();

            services.AddTransient<ICreateCarCommand, EfCreateCarCommand>();
            services.AddTransient<IDeleteCarCommand, EfDeleteCarCommand>();
            services.AddTransient<IEditCarCommand, EfEditCarCommand>();

            services.AddTransient<ICreateDebtCollectionCommand, EfCreateDebtCollectionCommand>();
            services.AddTransient<IEditDebtCollectionCommand, EfEditDebtCollectionCommand>();

            services.AddTransient<ICreateDebtorCommand, EfCreateDebtorCommand>();
            services.AddTransient<IEditDebtorCommand, EfEditDebtorCommand>();

            services.AddTransient<ICreateLocationPriceCommand, EfCreateLocationPriceCommand>();
            services.AddTransient<IEditLocationPriceCommand, EfEditLocationPriceCommand>();

            services.AddTransient<ICreateLocationCommand, EfCreateLocationCommand>();
            services.AddTransient<IEditLocationCommand, EfEditLocationCommand>();

            services.AddTransient<ICreateMaintenanceCommand, EfCreateMaintenanceCommand>();
            services.AddTransient<IEditMaintenanceCommand, EfEditMaintenanceCommand>();

            services.AddTransient<ICreateRideCommand, EfCreateRideCommand>();
            services.AddTransient<IEditRideCommand, EfEditRideCommand>();

            services.AddTransient<ICreateShiftCommand, EfCreateShiftCommand>();
            services.AddTransient<IEditShiftCommand, EfEditShiftCommand>();

            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();

        }
    }
}
