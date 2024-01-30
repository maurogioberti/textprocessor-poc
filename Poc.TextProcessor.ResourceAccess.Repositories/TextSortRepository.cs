using Poc.TextProcessor.CrossCutting.Utils;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;
using Poc.TextProcessor.ResourceAccess.Domains;
using Poc.TextProcessor.ResourceAccess.Entities;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;
using Poc.TextProcessor.ResourceAccess.Repositories.Base;

namespace Poc.TextProcessor.ResourceAccess.Repositories
{
    public class TextSortRepository(IDatabaseProvider databaseProvider) : RepositoryBase(databaseProvider), ITextSortRepository
    {
        public IEnumerable<TextSort> List()
        {
            var textSorts = _databaseProvider.Get<TextSortEntity>().ToList();
            return AutoMap.Map<TextSortEntity, TextSort>(textSorts);
        }
    }
}