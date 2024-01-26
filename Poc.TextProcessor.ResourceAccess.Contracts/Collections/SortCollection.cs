namespace Poc.TextProcessor.ResourceAccess.Contracts.Collections
{
    public record SortCollection(IEnumerable<Sort> Items, int TotalCount);
}