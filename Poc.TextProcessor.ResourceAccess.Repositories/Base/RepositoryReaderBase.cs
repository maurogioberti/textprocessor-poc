using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Repositories.Base
{
    public class RepositoryReaderBase(IDatabaseReaderProvider databaseProvider)
    {
        protected readonly IDatabaseReaderProvider _databaseProvider = databaseProvider;
    }
}