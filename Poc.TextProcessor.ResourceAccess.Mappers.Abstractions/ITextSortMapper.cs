using Poc.TextProcessor.ResourceAccess.Contracts.Collections;

namespace Poc.TextProcessor.ResourceAccess.Mappers
{
    public interface ITextSortMapper
    {
        SortCollection MapCollection(IEnumerable<Domains.TextSort> items);
    }
}