using BloodBankSystem.Application.Commands.Donor.CreateDonor;
using BloodBankSystem.Application.Validators;
using BloodBankSystem.Core.Services;
using BloodBankSystem.Infrastructure.ExternalServices.ViaCep;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;

namespace BloodBankSystem.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers().AddValidation();
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

    }
}
