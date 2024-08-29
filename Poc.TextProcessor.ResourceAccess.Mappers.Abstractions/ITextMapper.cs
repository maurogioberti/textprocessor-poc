using Poc.TextProcessor.ResourceAccess.Contracts.Collections;

namespace Poc.TextProcessor.ResourceAccess.Mappers
{
    public interface ITextMapper
    {
        Contracts.Text Map(Domains.Text text);
        TextCollection MapCollection(IEnumerable<Domains.Text> items);
    }
}