using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.API.Core;
using Taxi.API.DTO;
using Taxi.API.ErrorLogging;
using Taxi.API.Extensions;
using Taxi.API.Jwt.TokenStorage;
using Taxi.API.Jwt;
using Taxi.API.Vaidators;
using Taxi.Application.Logging;
using Taxi.Application.UseCases;
using Taxi.Application.UseCases.Queries.Debtor;
using Taxi.DatabaseAccess;
using Taxi.Implementation;
using Taxi.Implementation.Logging;
using Taxi.Implementation.UseCases.Queries.EfDebtors;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Taxi.Application;

namespace Taxi.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();

            Configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            AutoMapperConfiguration.InitAutoMapper();

            services.AddTaxiDbContext();

            services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<TaxiDbContext>();
                var tokenStorage = x.GetService<ITokenStorage>();
                return new JwtManager(context, appSettings.Jwt.Issuer, appSettings.Jwt.SecretKey, appSettings.Jwt.DurationSeconds, tokenStorage);
            });

            services.AddHttpContextAccessor(); services.AddScoped<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var data = header.ToString().Split("Bearer ");

                if (data.Length < 2)
                {
                    throw new UnauthorizedAccessException();
                }

                var handler = new JwtSecurityTokenHandler();

                var tokenObj = handler.ReadJwtToken(data[1].ToString());

                var claims = tokenObj.Claims;

                var id = claims.First(x => x.Type == "Id").Value;
                var username = claims.First(x => x.Type == "Username").Value;
                var useCases = claims.First(x => x.Type == "UseCases").Value;

                List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

                return new JwtUser
                {
                    AllowedUseCases = useCaseIds,
                    Id = int.Parse(id),
                    Username = username,
                };
            });

            //services.AddTransient<TaxiDbContext>(x =>
            //{
            //    DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            //    builder.UseSqlServer("Data Source=localhost; Initial Catalog = Taxi; Integrated Security = true");
            //    return new TaxiDbContext(builder.Options);
            //});

            services.AddTransient<IErrorLogger, ConsoleErrorLogger>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();

            services.AddValidators();
            services.AddUseCases();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Taxi.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taxi.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
