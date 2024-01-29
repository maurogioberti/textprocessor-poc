using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Poc.TextProcessor.CrossCutting.Configurations;
using Poc.TextProcessor.CrossCutting.Configurations.Database;
using Poc.TextProcessor.CrossCutting.Globalization;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework
{
    /// <summary>
    /// This class is solely for Entity Framework design-time purposes.
    /// It's used locally for initializing the database and generating migrations.
    /// </summary>
    public class PocContextFactory : IDesignTimeDbContextFactory<PocContext>
    {
        public PocContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppConfigurations.AppSettingsFileName)
                .Build();

            var databaseProvider = configuration.GetValue<string>(DatabaseSettings.Provider);
            var connectionString = databaseProvider switch
            {
                DatabaseSettings.SqlServer => configuration.GetConnectionString(ConnectionString.SqlServerConnection),
                DatabaseSettings.Sqlite => configuration.GetConnectionString(ConnectionString.SqliteConnection),
                _ => throw new ArgumentException(Messages.InvalidDatabaseProvider)
            };
            var optionsBuilder = new DbContextOptionsBuilder<PocContext>();
            DatabaseServiceConfigurationHelpers.SetDatabaseProvider(databaseProvider, connectionString, optionsBuilder);

            return new PocContext(optionsBuilder.Options);
        }
    }
}