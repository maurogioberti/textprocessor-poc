using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Repositories.Base
{
    public class RepositoryBase
    {
        protected readonly IDatabaseProvider _databaseProvider;

        public RepositoryBase(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }
    }
}