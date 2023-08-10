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
using Taxi.Application.UseCases.Queries.Shift;
using Taxi.Application.UseCases.Commands.CarBrand;
using Taxi.Application.UseCases.Commands.Car;
using Taxi.Application.UseCases.Commands.DebtCollection;
using Taxi.Application.UseCases.Commands.Debtor;
using Taxi.Application.UseCases.Commands.LocationPrice;
using Taxi.Application.UseCases.Commands.Location;
using Taxi.Application.UseCases.Commands.Maintenance;
using Taxi.Application.UseCases.Commands.Ride;
using Taxi.Application.UseCases.Commands.Shift;
using Taxi.Application.UseCases.Commands.User;
using Taxi.Application.Logging;
using Taxi.Application.UseCases.Queries;
using Taxi.Implementation.UseCases.Queries;
using Taxi.Implementation.UseCases.Queries.DapperCars;
using Taxi.Implementation.UseCases.Queries.DapperCarBrands;
using Taxi.Implementation.UseCases.Queries.DapperCarModels;
using Taxi.Implementation.UseCases.Queries.DapperDebtors;
using Taxi.Implementation.UseCases.Queries.DapperFuelTypes;
using Taxi.Implementation.UseCases.Queries.DapperLocationPrices;
using Taxi.Implementation.UseCases.Queries.DapperMaintenances;
using Taxi.Implementation.UseCases.Queries.DapperLocations;
using Taxi.Implementation.UseCases.Queries.DapperMaintenancesTypes;
using Taxi.Implementation.UseCases.Queries.DapperRides;
using Taxi.Implementation.UseCases.Queries.DapperShifts;
using Taxi.Implementation.UseCases.Queries.DapperUsers;
using Taxi.Implementation.UseCases.Commands.DapperCarBrands;
using Taxi.Implementation.UseCases.Commands.DapperCarModels;
using Taxi.Implementation.UseCases.Commands.DapperCars;
using Taxi.Implementation.UseCases.Commands.DapperDebtCollection;
using Taxi.Implementation.UseCases.Commands.DapperDebtors;
using Taxi.Implementation.UseCases.Commands.DapperLocationPrices;
using Taxi.Implementation.UseCases.Commands.DapperLocations;
using Taxi.Implementation.UseCases.Commands.DapperMaintenances;
using Taxi.Implementation.UseCases.Commands.DapperRides;
using Taxi.Implementation.UseCases.Commands.DapperShifts;
using Taxi.Implementation.UseCases.Commands.DapperUsers;
using Taxi.Implementation.UseCases.Commands;

namespace Taxi.API.Extensions
{
    public static class UseCaseExtension
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();


            //query

            services.AddTransient<IGetCarBrandsQuery, DapperGetCarBrandsQuery>();
            services.AddTransient<IFindCarBrandQuery, DapperFindCarBrandQuery>();

            services.AddTransient<IGetCarModelsQuery, DapperGetCarModelsQuery>();
            services.AddTransient<IFindCarModelQuery, DapperFindCarModelQuery>();

            services.AddTransient<IGetCarsQuery, DapperGetCarsQuery>();
            services.AddTransient<IFindCarQuery, DapperFindCarQuery>();

            services.AddTransient<IGetDebtorsQuery, DapperGetDebtorsQuery>();
            services.AddTransient<IFindDebtorQuery, DapperFindDebtorQuery>();

            services.AddTransient<IGetFuelTypesQuery, DapperGetFuelTypesQuery>();
            services.AddTransient<IFindFuelTypeQuery, DapperFindFuelTypeQuery>();

            services.AddTransient<IGetMaintenancesQuery, DapperGetMaintenancesQuery>();
            services.AddTransient<IFindMaintenanceQuery, DapperFindMaintenanceQuery>();

            services.AddTransient<IGetLocationPricesQuery, DapperGetLocationPricesQuery>();
            services.AddTransient<IFindLocationPriceQuery, DapperFindLocationPriceQuery>(); 
            services.AddTransient<IFindFinishLocationPriceQuery, DapperFindFinishLocationPriceQuery>(); 

            services.AddTransient<IGetLocationsQuery, DapperGetLocationsQuery>();
            services.AddTransient<IFindLocationQuery, DapperFindLocationQuery>();

            services.AddTransient<IGetMaintenanceTypesQuery, DapperGetMaintenanceTypesQuery>();
            services.AddTransient<IFindMaintenanceTypeQuery, DapperFindMaintenanceTypeQuery>();

            services.AddTransient<IGetRidesQuery, DapperGetRidesQuery>();
            services.AddTransient<IFindShiftRidesQuery, DapperFindShiftRidesQuery>();
            services.AddTransient<IFindRideQuery, DapperFindRideQuery>();

            services.AddTransient<IGetShiftsQuery, DapperGetShiftsQuery>();
            services.AddTransient<IFindShiftQuery, DapperFindShiftQuery>();
            services.AddTransient<IFindUnfinishedShiftQuery, DapperFindUnfinishedShiftQuery>();
            services.AddTransient<IGetUserShifts, DapperGetUserShiftsQuery>();

            services.AddTransient<IGetUsersQuery, DapperGetUsersQuery>();
            services.AddTransient<IFindUserQuery, DapperFindUserQuery>();

            services.AddTransient<IGetLogEntries, EfGetLogEntriesQuery>();
            
            //command

            services.AddTransient<ICreateCarBrandCommand, DapperCreateCarBrandCommand>();
            services.AddTransient<IEditCarBrandCommand, DapperEditCarBrandCommand>();

            services.AddTransient<ICreateCarModelCommand, DapperCreateCarModelCommand>();
            services.AddTransient<IEditCarModelCommand, DapperEditCarModelCommand>();

            services.AddTransient<ICreateCarCommand, DapperCreateCarCommand>();
            services.AddTransient<IDeleteCarCommand, DapperDeleteCarCommand>();
            services.AddTransient<IEditCarCommand, DapperEditCarCommand>();

            services.AddTransient<ICreateDebtCollectionCommand, DapperCreateDebtCollectionCommand>();
            services.AddTransient<IEditDebtCollectionCommand, DapperEditDebtCollectionCommand>();

            services.AddTransient<ICreateDebtorCommand, DapperCreateDebtorCommand>();
            services.AddTransient<IEditDebtorCommand, DapperEditDebtorCommand>();

            services.AddTransient<ICreateLocationPriceCommand, DapperCreateLocationPriceCommand>();
            services.AddTransient<IEditLocationPriceCommand, DapperEditLocationPriceCommand>();

            services.AddTransient<ICreateLocationCommand, DapperCreateLocationCommand>();
            services.AddTransient<IEditLocationCommand, DapperEditLocationCommand>();

            services.AddTransient<ICreateMaintenanceCommand, DapperCreateMaintenanceCommand>();
            services.AddTransient<IEditMaintenanceCommand, DapperEditMaintenanceCommand>();

            services.AddTransient<ICreateRideCommand, DapperCreateRideCommand>();
            services.AddTransient<IEditRideCommand, DapperEditRideCommand>();

            services.AddTransient<ICreateShiftCommand, DapperCreateShiftCommand>();
            services.AddTransient<IEditShiftCommand, DapperEditShiftCommand>();

            services.AddTransient<ICreateUserCommand, DapperCreateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DapperDeleteUserCommand>();
            services.AddTransient<IEditUserCommand, DapperEditUserCommand>();


            services.AddTransient<IAzureStorage, AzureStorage>();
        }
    }
}
