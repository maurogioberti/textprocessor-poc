namespace Poc.TextProcessor.ResourceAccess.Mappers
{
    public interface ITextMapper
    {
        Contracts.Text Map(Domains.Text text);
    }
}