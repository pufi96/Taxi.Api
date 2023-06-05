using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.API.Core;
using Taxi.API.DTO;
using Taxi.API.Jwt;
using Taxi.Application.Exceptions;
using Taxi.Application.Logging;
using Taxi.Application.UseCases;
using Taxi.Application.UseCases.Commands.CarModel;
using Taxi.Application.UseCases.Queries;
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
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Logging;
using Taxi.Implementation.UseCases.Commands.EfCarModels;
using Taxi.Implementation.UseCases.Queries;
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
    public static class ContainerExtension
    {
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.Jwt.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                cfg.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        //Token dohvatamo iz Authorization header-a

                        var header = context.Request.Headers["Authorization"];

                        var token = header.ToString().Split("Bearer ")[1];

                        var handler = new JwtSecurityTokenHandler();

                        var tokenObj = handler.ReadJwtToken(token);

                        string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;


                        //ITokenStorage

                        ITokenStorage storage = context.HttpContext.RequestServices.GetService<ITokenStorage>();

                        bool isValid = storage.TokenExists(jti);

                        if (!isValid)
                        {
                            context.Fail("Token is not valid.");
                        }

                        return Task.CompletedTask;
                    }
                };
            });
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
