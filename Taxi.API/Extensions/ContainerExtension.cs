using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Taxi.API.Core;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Queries;
using Taxi.Application.UseCases.Queries.ICarBrand;
using Taxi.Application.UseCases.Queries.ICarBrandQuery;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.UseCases.Queries;
using Taxi.Implementation.UseCases.Queries.EfCarBrands;

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
            services.AddTransient<IGetCarBrandQuery, EfGetCarBrandsQuery>();
            services.AddTransient<IFindCarBrandQuery, EfFindCarBrandsQuery>();






            services.AddTransient<ISearchShiftQuery, EfSearchShiftQuery>();
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
