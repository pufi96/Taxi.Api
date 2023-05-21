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
using Taxi.API.Vaidators;
using Taxi.DatabaseAccess;
using Taxi.Implementation;

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
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = new AppSettings();

            Configuration.Bind(settings);

            services.AddSingleton(settings);
            services.AddTaxiDbContext();
            services.AddTransient<UseCaseHandler>();

            services.AddTransient<IErrorLogger, ConsoleErrorLogger>();
            //services.AddTransient<TaxiDbContext>(x =>
            //{
            //    DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            //    builder.UseSqlServer("Data Source=localhost; Initial Catalog = Taxi; Integrated Security = true");
            //    return new TaxiDbContext(builder.Options);
            //});

            services.AddTransient<CreateCarBrandValidator>();
            services.AddTransient<CreateCarModelValidator>();

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
