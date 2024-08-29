using Poc.TextProcessor.CrossCutting.Utils.Mapper;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;
using Poc.TextProcessor.ResourceAccess.Domains;
using Poc.TextProcessor.ResourceAccess.Entities;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;
using Poc.TextProcessor.ResourceAccess.Repositories.Base;

namespace Poc.TextProcessor.ResourceAccess.Repositories
{
    public class TextRepository(IDatabaseManagerProvider databaseProvider) : RepositoryManagerBase(databaseProvider), ITextRepository
    {
        public Text Get(int id)
        {
            var text = _databaseProvider.Get<TextEntity>(x => x.Id == id).Single();
            return AutoMap.Map<TextEntity, Text>(text);
        }

        public void Remove(int id)
        {
            var text = _databaseProvider.Get<TextEntity>(x => x.Id == id).Single();
            _databaseProvider.Remove(text);
        }

        public IEnumerable<Text> Get()
        {
            var text = _databaseProvider.Get<TextEntity>();
            return AutoMap.Map<TextEntity, Text>(text);
        }
    }
}