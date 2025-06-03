using BloodBankSystem.Application.Commands.Donor.CreateDonor;
using BloodBankSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBankSystem.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();
            services.AddHandlers();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IBloodStockService, BloodStockService>();
            services.AddScoped<IDonationService, DonationService>();
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                                config.RegisterServicesFromAssemblyContaining<CreateDonorCommand>()
                                );
            return services;
        }


    }
}
