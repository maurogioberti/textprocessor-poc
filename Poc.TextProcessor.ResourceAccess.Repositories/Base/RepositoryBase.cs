using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Repositories.Base
{
    public class RepositoryBase(IDatabaseProvider databaseProvider)
    {
        protected readonly IDatabaseProvider _databaseProvider = databaseProvider;
    }
}