using Poc.TextProcessor.ResourceAccess.Contracts.Collections;

namespace Poc.TextProcessor.ResourceAccess.Mappers
{
    public class TextMapper : ITextMapper
    {
        public Contracts.Text Map(Domains.Text text) => new Contracts.Text
        {
            Id = text.Id,
            Content = text.Content
        };

        public TextCollection MapCollection(IEnumerable<Domains.Text> items)
        {
            var contracts = items.Select(Map);
            return new TextCollection(contracts, contracts.Count());
        }
    }
}