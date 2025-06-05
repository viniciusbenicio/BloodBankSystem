using BloodBankSystem.Application.Commands.Donor.CreateDonor;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBankSystem.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();
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
