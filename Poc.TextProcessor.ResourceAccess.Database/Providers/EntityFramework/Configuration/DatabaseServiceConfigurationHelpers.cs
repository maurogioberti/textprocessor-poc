using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Poc.TextProcessor.CrossCutting.Configurations.Database;
using Poc.TextProcessor.CrossCutting.Globalization;
using Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Connectors;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Configuration
{
    internal static class DatabaseServiceConfigurationHelpers
    {
        public static void InitializeDatabaseProvider(IConfiguration configuration, DbContextOptionsBuilder options)
        {
            // Define strategy based on the provider
            var databaseProvider = configuration.GetValue<string>(DatabaseSettings.Provider);
            IDatabaseConnector databaseConnector = databaseProvider switch
            {
                DatabaseSettings.SqlServer => new SqlServerDatabaseConnector(),
                DatabaseSettings.Sqlite => new SqliteDatabaseConnector(),
                _ => throw new ArgumentException(Messages.InvalidDatabaseProvider)
            };

            // Use the strategy to configure the database
            databaseConnector.ConfigureDatabase(options, configuration);
        }
    }
}