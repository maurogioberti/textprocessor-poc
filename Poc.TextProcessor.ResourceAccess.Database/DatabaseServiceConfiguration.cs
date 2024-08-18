using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.TextProcessor.CrossCutting.Configurations.Database;
using Poc.TextProcessor.CrossCutting.Globalization;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.Configuration
{
    public static class DatabaseServiceConfiguration
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Define strategy based on the Framework ORM
            var databaseFramework = configuration.GetValue<string>(DatabaseSettings.Framework);
            switch (databaseFramework)
            {
                case DatabaseFrameworks.EntityFramework:
                    EntityFramework.Configuration.DatabaseServiceConfiguration.ConfigureDatabaseServices(services, configuration);
                    break;
                case DatabaseFrameworks.NHibernate:
                    NHibernate.Configuration.DatabaseServiceConfiguration.ConfigureDatabaseServices(services, configuration);
                    break;
                default:
                    throw new ArgumentException(Messages.InvalidDatabaseFramework);
            };
        }
    }
}