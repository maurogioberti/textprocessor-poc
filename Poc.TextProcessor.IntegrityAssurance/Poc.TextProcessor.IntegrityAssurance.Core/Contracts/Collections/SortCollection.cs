namespace Poc.TextProcessor.IntegrityAssurance.Core.Contracts.Collections
{
    public record SortCollection(IEnumerable<Sort> Items, int TotalCount);
}
