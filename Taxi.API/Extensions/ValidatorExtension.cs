using Microsoft.Extensions.DependencyInjection;
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
