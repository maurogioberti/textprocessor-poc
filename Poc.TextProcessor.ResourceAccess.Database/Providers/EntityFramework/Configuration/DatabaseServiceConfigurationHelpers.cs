using Microsoft.EntityFrameworkCore;
using Poc.TextProcessor.CrossCutting.Configurations.Database;
using Poc.TextProcessor.CrossCutting.Globalization;

internal static class DatabaseServiceConfigurationHelpers
{
    public static void SetDatabaseProvider(string databaseProvider, string connectionString, DbContextOptionsBuilder options)
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
    }
}