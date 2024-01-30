using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Poc.TextProcessor.CrossCutting.Configurations;

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

            var optionsBuilder = new DbContextOptionsBuilder<PocContext>();
            DatabaseServiceConfigurationHelpers.InitializeDatabaseProvider(configuration, optionsBuilder);

            return new PocContext(optionsBuilder.Options);
        }
    }
}