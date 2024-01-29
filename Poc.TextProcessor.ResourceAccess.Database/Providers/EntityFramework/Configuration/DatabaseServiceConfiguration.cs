using Microsoft.Extensions.DependencyInjection;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Configuration
{
    public static class DatabaseServiceConfiguration
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, string databaseProvider, string connectionString)
        {
            services.AddDbContext<PocContext>(options =>
            {
                DatabaseServiceConfigurationHelpers.SetDatabaseProvider(databaseProvider, connectionString, options);
            });

            services.AddScoped<IDatabaseProvider, EntityFrameworkDatabaseProvider>();
        }
    }
}