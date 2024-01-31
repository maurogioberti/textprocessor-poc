namespace Poc.TextProcessor.IntegrityAssurance.Core.Contracts
{
    public record Sort
    {
        public int Id { get; init; }
        public string Option { get; init; } = string.Empty;
    }
}