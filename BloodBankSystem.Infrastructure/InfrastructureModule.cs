using BloodBankSystem.Core;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Core.Services;
using BloodBankSystem.Infrastructure.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using BloodBankSystem.Infrastructure.ExternalServices.Email;
using BloodBankSystem.Infrastructure.ExternalServices.ViaCep;
using BloodBankSystem.Infrastructure.Persistence;
using BloodBankSystem.Infrastructure.Persistence.Repositores;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBankSystem.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfraescrture(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddRepositories().AddData(configuration).AddBackgroundServices(configuration);
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BloodBankSystemDBContext>(b => b.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IBloodStockRepository, BloodStockRepository>();
            services.AddScoped<IJobRepository, JobRepository>();

            return services;
        }

        public static IServiceCollection AddServicesExternal(this IServiceCollection services)
        {
            services.AddScoped<ICEPService, ViaCepService>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }

        public static IServiceCollection AddUnifOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddBackgroundServices(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddHangfire((sp, config) =>
            {
                config.UseSqlServerStorage(connectionString);
            });

            services.AddHangfireServer();

            return services;
        }

    }
}
