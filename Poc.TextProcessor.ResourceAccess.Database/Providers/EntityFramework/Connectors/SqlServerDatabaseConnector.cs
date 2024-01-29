using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Poc.TextProcessor.CrossCutting.Configurations.Database;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Connectors
{
    public class SqlServerDatabaseConnector : IDatabaseConnector
    {
        public void ConfigureDatabase(DbContextOptionsBuilder options, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionString.SqlServerConnection);
            options.UseSqlServer(connectionString);
        }
    }
}