namespace Poc.TextProcessor.ResourceAccess.Contracts
{
    public record Statistics
    {
        public int Hypens { get; init; }
        public int Words { get; init; }
        public int Spaces { get; init; }
    }
}