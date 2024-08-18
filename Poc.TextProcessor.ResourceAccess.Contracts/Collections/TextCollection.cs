namespace Poc.TextProcessor.ResourceAccess.Contracts.Collections
{
    public record TextCollection(IEnumerable<Text> Items, int TotalCount);
}