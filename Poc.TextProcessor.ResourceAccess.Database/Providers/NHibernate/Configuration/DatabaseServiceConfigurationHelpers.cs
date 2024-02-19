
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cache;
using Poc.TextProcessor.CrossCutting.Configurations.Database;
using Poc.TextProcessor.CrossCutting.Globalization;
using System.Reflection;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.NHibernate.Configuration
{
    internal static class DatabaseServiceConfigurationHelpers
    {
        public static ISessionFactory BuildSessionFactory(IConfiguration configuration)
        {
            // Use the strategy to configure the database
            IPersistenceConfigurer databaseConfig = ConfigureDatabaseProvider(configuration);

            // Define strategy based on the provider
            return Fluently.Configure()
                .Database(databaseConfig)
                .Cache(
                    c => c.UseQueryCache()
                        .UseSecondLevelCache()
                        .ProviderClass<HashtableCacheProvider>())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load(NHibernateSettings.MappingAssembly)))
                .BuildSessionFactory();
        }

        private static IPersistenceConfigurer ConfigureDatabaseProvider(IConfiguration configuration)
        {
            var databaseProvider = configuration.GetValue<string>(DatabaseSettings.Provider);

            IPersistenceConfigurer databaseConfig = databaseProvider switch
            {
                DatabaseSettings.Sqlite => SQLiteConfiguration.Standard
                    .ConnectionString(configuration.GetConnectionString(ConnectionString.SqliteConnection)),
                DatabaseSettings.SqlServer => MsSqlConfiguration.MsSql2012
                        .ConnectionString(configuration.GetConnectionString(ConnectionString.SqlServerConnection)),
                _ => throw new ArgumentException(Messages.InvalidDatabaseProvider)
            };
            return databaseConfig;
        }
    }
}