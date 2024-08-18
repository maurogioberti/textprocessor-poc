namespace Poc.TextProcessor.IntegrityAssurance.Core.Contracts.Collections
{
    public record TextCollection(IEnumerable<Text> Items, int TotalCount);
}
