using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Connectors
{
    public interface IDatabaseConnector
    {
        void ConfigureDatabase(DbContextOptionsBuilder options, IConfiguration configuration);
    }
}