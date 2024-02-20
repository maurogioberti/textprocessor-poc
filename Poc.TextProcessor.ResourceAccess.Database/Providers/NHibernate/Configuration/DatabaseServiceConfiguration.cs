using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.NHibernate.Configuration
{
    public static class DatabaseServiceConfiguration
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(DatabaseServiceConfigurationHelpers.BuildSessionFactory(configuration));

            services.AddScoped<IDatabaseReaderProvider, NHibernateReaderProvider>();
            services.AddScoped<IDatabaseWriterProvider, NHibernateWriterProvider>();
            services.AddScoped<IDatabaseManagerProvider, NHibernateManagerProvider>();
        }
    }
}