using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Repositories.Base
{
    public class RepositoryWriterBase(IDatabaseWriterProvider databaseProvider)
    {
        protected readonly IDatabaseWriterProvider _databaseProvider = databaseProvider;
    }
}