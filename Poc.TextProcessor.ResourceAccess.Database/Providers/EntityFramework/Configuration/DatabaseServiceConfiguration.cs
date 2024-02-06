using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Configuration
{
    public static class DatabaseServiceConfiguration
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PocContext>(options =>
            {
                DatabaseServiceConfigurationHelpers.InitializeDatabaseProvider(configuration, options);
            });

            services.AddScoped<IDatabaseReaderProvider, EntityFrameworkReaderProvider>();
            services.AddScoped<IDatabaseWriterProvider, EntityFrameworkWriterProvider>();
            services.AddScoped<IDatabaseManagerProvider, EntityFrameworkManagerProvider>();
        }
    }
}