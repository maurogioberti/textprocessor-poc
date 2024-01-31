namespace Poc.TextProcessor.IntegrityAssurance.Core.Contracts
{
    public record Text
    {
        public int Id { get; init; }
        public string Content { get; init; } = string.Empty;
    }
}