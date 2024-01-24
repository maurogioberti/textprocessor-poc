namespace Poc.TextProcessor.ResourceAccess.Repositories.Abstractions
{
    public interface ITextRepository
    {
        Domains.Text Get(int id);
    }
}