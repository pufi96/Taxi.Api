using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Taxi.API.Core;
using Taxi.Application.UseCases.Queries;
using Taxi.DatabaseAccess;
using Taxi.Implementation.UseCases.Queries;

namespace Taxi.API.Extensions
{
    public static class ContainerExtension
    {
        public static void AddUseCases(this IServiceCollection services)
        {
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
