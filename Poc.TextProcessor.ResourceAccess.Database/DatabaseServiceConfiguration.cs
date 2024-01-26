using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Poc.TextProcessor.CrossCutting.Configurations.Database;
using Poc.TextProcessor.CrossCutting.Globalization;
using Poc.TextProcessor.ResourceAccess.Database.EntityFramework;

namespace Poc.TextProcessor.ResourceAccess.Database
{
    public static class DatabaseServiceConfiguration
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, string databaseProvider, string connectionString)
        {
            services.AddDbContext<PocContext>(options =>
            {
                switch (databaseProvider)
                {
                    case DatabaseSettings.SqlServer:
                        options.UseSqlServer(connectionString);
                        break;
                    case DatabaseSettings.Sqlite:
                        options.UseSqlite(connectionString);
                        break;
                    default:
                        throw new ArgumentException(Messages.InvalidDatabaseProvider);
                }
            });

            services.AddScoped<IDatabaseProvider, EntityFrameworkDatabaseProvider>();
        }
    }
}