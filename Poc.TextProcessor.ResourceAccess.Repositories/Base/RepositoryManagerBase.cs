using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Repositories.Base
{
    public class RepositoryManagerBase(IDatabaseManagerProvider databaseProvider)
    {
        protected readonly IDatabaseManagerProvider _databaseProvider = databaseProvider;
    }
}