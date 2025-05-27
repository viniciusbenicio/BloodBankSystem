using BloodBankSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBankSystem.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IBloodStockService, BloodStockService>();
            services.AddScoped<IDonationService, DonationService>();
            return services;
        }


    }
}
