using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialController : ControllerBase
    {
        // GET: api/<InitialController>
        [HttpGet]
        public IActionResult Get([FromServices] TaxiDbContext context)
        {
            
            var role = new List<Role>
            {
                new Role { RoleName = "Master" },
                new Role { RoleName = "Driver" }
            };

            var masterRole = new List<RoleUseCase>();
            for (int i = 1; i < 50; i++)
            {
                masterRole.Add(new RoleUseCase { Role = role.ElementAt(0), UseCaseId = i });
            }
            int[] driverUseCases = { 7, 8, 13, 14, 15, 16, 19, 20, 21, 22, 23, 24, 34, 44};
            var driverRole = new List<RoleUseCase>();
            for (int i = 0;i < driverUseCases.Length; i++)
            {
                driverRole.Add(new RoleUseCase { Role = role.ElementAt(1), UseCaseId = driverUseCases[i] });
            }
            var roleUseCase = new List<RoleUseCase>();
            roleUseCase.AddRange(masterRole);
            roleUseCase.AddRange(driverRole);
            

            var password = BCrypt.Net.BCrypt.HashPassword("Admin12345.");
            var user = new List<User>
            {
                new User { Username = "master", FirstName = "Taxi", LastName ="Master", Earnings = 100, Email = "master@gmail.com", Password = password, UserRole = role.ElementAt(0) },
                new User { Username = "zika", FirstName = "Zika", LastName ="Zikic", Earnings = 20, Email = "zika@gmail.com", Password = password, UserRole = role.ElementAt(1) }
            };

            var carBrand = new List<CarBrand>
            {
                new CarBrand { CarBrandName = "Peugeot" },
                new CarBrand { CarBrandName = "Fiat" }
            };

            var carModel = new List<CarModel>
            {
                new CarModel { CarModelName = "206", CarBrand = carBrand.ElementAt(0) },
                new CarModel { CarModelName = "Stilo", CarBrand = carBrand.ElementAt(1) }
            };
            
            var fuelType = new List<FuelType>
            {
                new FuelType { FuelTypeName = "Diesel"},
                new FuelType { FuelTypeName = "Gasoline"},
                new FuelType { FuelTypeName = "TNG"},
                new FuelType { FuelTypeName = "Gasoline + TNG"},
                new FuelType { FuelTypeName = "CNG"},
                new FuelType { FuelTypeName = "Gasoline + CNG"},
                new FuelType { FuelTypeName = "Electric"}
            };

            var car = new List<Car>
            {
                new Car { CarModel = carModel.ElementAt(0), ChassisNumber = "1", Color = "Blue", Description = "NOV NOV NOV", EngineVolume = 1200, HorsePower = 80, FuelType = fuelType.ElementAt(0), Mileage = 0, ImageFilePath = "img1.png", Registration = "BC 0001 BC", ValidityOfRegistration = DateTime.UtcNow},
                new Car { CarModel = carModel.ElementAt(1), ChassisNumber = "2", Color = "Black", Description = "Ne radi", EngineVolume = 1200, HorsePower = 180, FuelType = fuelType.ElementAt(1), Mileage = 100000, ImageFilePath = "img2.png", Registration = "BC 0002 BC", ValidityOfRegistration = DateTime.UtcNow}
            };

            var maintenanceType = new List<MaintenanceType>
            {
                new MaintenanceType { MaintenanceTypeName = "Interim service" },
                new MaintenanceType { MaintenanceTypeName = "Full service" },
                new MaintenanceType { MaintenanceTypeName = "Major service" }
            };

            var maintenance = new List<Maintenance>
            {
                new Maintenance { Car = car.ElementAt(0), MaintenanceType = maintenanceType.ElementAt(0), Description = "Windscreen wipers change", Mileage = 0, DateStart = DateTime.UtcNow, DateEnd = DateTime.UtcNow+ TimeSpan.FromHours(24), Price = 200 },
                new Maintenance { Car = car.ElementAt(1), MaintenanceType = maintenanceType.ElementAt(1), Description = "Oil filters change", Mileage = 10000, DateStart = DateTime.UtcNow, DateEnd = DateTime.UtcNow+ TimeSpan.FromHours(24), Price = 100 }

            };

            var shift = new List<Shift>
            {
                new Shift { Car = car.ElementAt(0), Earnings = 200, Description = "Only 1 ride", Expenses = 0, MileageStart = 0, MileageEnd = 20, ShiftStart = DateTime.UtcNow, ShiftEnd = DateTime.UtcNow+ TimeSpan.FromHours(24), Turnover = 200, User = user.ElementAt(0)},
                new Shift { Car = car.ElementAt(1), Earnings = 200, Description = "Only 1 ride", Expenses = 0, MileageStart = 100000, MileageEnd = 100010, ShiftStart = DateTime.UtcNow, ShiftEnd = DateTime.UtcNow+ TimeSpan.FromHours(24), Turnover = 70, User = user.ElementAt(1)}
            };

            var location = new List<Location>
            {
                new Location { LocationName = "Bela Crkva" },
                new Location { LocationName = "Crvena Crkva" },
                new Location { LocationName = "Kusic" },
                new Location { LocationName = "Kruscica" }
            };

            var locationPrice = new List<LocationPrice>
            {
                new LocationPrice { LocationStart = location.ElementAt(0), LocationEnd = location.ElementAt(2), Price = 200 },
                new LocationPrice { LocationStart = location.ElementAt(1), LocationEnd = location.ElementAt(3), Price = 100 }
            };

            var ride = new List<Ride>
            {
                new Ride { IsLocal = false, LocationPrice = locationPrice.ElementAt(0), Shift = shift.ElementAt(0), RidePrice = 200},
                new Ride { IsLocal = false, LocationPrice = locationPrice.ElementAt(0), Shift = shift.ElementAt(1), RidePrice = 100}
            };

            var debtor = new List<Debtor>
            {
                new Debtor { DebtorFirstName = "Mika", DebtorLastName = "Mikic", Description = "Partizanska 22"},
                new Debtor { DebtorFirstName = "Pera", DebtorLastName = "Peric", Description = "bb 23"}
            };

            var debtCollection = new List<DebtCollection>
            {
                new DebtCollection { DebtCollectionPrice = 100, Debtor = debtor.ElementAt(0)},
                new DebtCollection { DebtCollectionPrice = 700, Debtor = debtor.ElementAt(1)}
            };

            var inDebted = new List<InDebted>
            {
                new InDebted { Debtor = debtor.ElementAt(0), Ride = ride.ElementAt(1)},
                new InDebted { Debtor = debtor.ElementAt(1), Ride = ride.ElementAt(1)}
            };
           
            context.Roles.AddRange(role);
            context.RoleUseCases.AddRange(roleUseCase);
            context.CarBrands.AddRange(carBrand);
            context.CarModels.AddRange(carModel);
            context.FuelTypes.AddRange(fuelType);
            context.Cars.AddRange(car);
            context.MaintenanceTypes.AddRange(maintenanceType);
            context.Maintenances.AddRange(maintenance);
            context.Shifts.AddRange(shift);
            context.Locations.AddRange(location);
            context.LocationPrices.AddRange(locationPrice);
            context.Rides.AddRange(ride);
            context.Debtors.AddRange(debtor);
            context.DebtCollections.AddRange(debtCollection);
            context.InDebteds.AddRange(inDebted);

            context.SaveChanges();

            return StatusCode(201);
        }
    }
}
