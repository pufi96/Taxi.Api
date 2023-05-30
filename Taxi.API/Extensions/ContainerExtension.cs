using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Taxi.API.Core;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Queries;
using Taxi.Application.UseCases.Queries.Car;
using Taxi.Application.UseCases.Queries.CarModel;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.Application.UseCases.Queries.FuelType;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.UseCases.Queries;
using Taxi.Implementation.UseCases.Queries.EfCarBrands;
using Taxi.Implementation.UseCases.Queries.EfCarModel;
using Taxi.Implementation.UseCases.Queries.EfCars;
using Taxi.Implementation.UseCases.Queries.EfDebtors;
using Taxi.Implementation.UseCases.Queries.EfFuelTypes;

namespace Taxi.API.Extensions
{
    public static class ContainerExtension
    {
        public static void AddAppUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(s => 
            { 
                var httpContextAccessor = s.GetService<IHttpContextAccessor>(); 
                var claims = httpContextAccessor.HttpContext.User; 
                if (claims == null || claims.FindFirst("UserId") == null) 
                { 
                    //throw new NotLoggedInException(); 
                } 
                //var obj = new JwtUser() 
                //{ 
                //    Id = Convert.ToInt32(claims.FindFirst("UserId").Value), 
                //    Username = claims.FindFirst("Username").Value, 
                //    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCaseIds").Value) 
                //}; 
                return null; 
            });
        }
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IGetCarBrandsQuery, EfGetCarBrandsQuery>();
            services.AddTransient<IFindCarBrandsQuery, EfFindCarBrandsQuery>();

            services.AddTransient<IGetCarModelsQuery, EfGetCarModelsQuery>();
            services.AddTransient<IFindCarModelsQuery, EfFindCarModelsQuery>();

            services.AddTransient<IGetFuelTypesQuery, EfGetFuelTypesQuery>();
            services.AddTransient<IFindFuelTypesQuery, EfFindFuelTypesQuery>();

            services.AddTransient<IGetCarsQuery, EfGetCarsQuery>();
            services.AddTransient<IFindCarsQuery, EfFindCarsQuery>();

            services.AddTransient<IGetDebtorsQuery, EfGetDebtorsQuery>();
            services.AddTransient<IFindDebtorsQuery, EfFindDebtorsQuery>();






            //validators


        }

        public static void AddTaxiDbContext(this IServiceCollection services)
        {
            services.AddTransient(x =>
            {
                DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

                var connectionString = x.GetService<AppSettings>().ConnectionString;

                optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();

                var options = optionsBuilder.Options;

                return new TaxiDbContext(options);
            });
        }

    }
}
