using BloodBankSystem.Application.Commands.Donor.CreateDonor;
using BloodBankSystem.Application.Job;
using BloodBankSystem.Application.Validators;
using BloodBankSystem.Core.Services;
using BloodBankSystem.Infrastructure.ExternalServices.ViaCep;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBankSystem.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers().AddValidation().AddExternalServices().AddNotification();
            return services;
        }


        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                                config.RegisterServicesFromAssemblyContaining<CreateDonorCommand>()
                                );
            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                    .AddValidatorsFromAssemblyContaining<CreateDonorValidator>();


            services.AddHttpClient<ICEPService, ViaCepService>();



            return services;
        }

        private static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddHttpClient<ICEPService, ViaCepService>();

            return services;

        }

        private static IServiceCollection AddNotification(this IServiceCollection services)
        {
            services.AddTransient<NotificationTask>();


            return services;
        }

    }
}
