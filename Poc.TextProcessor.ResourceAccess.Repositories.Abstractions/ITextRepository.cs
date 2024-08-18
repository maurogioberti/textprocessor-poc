namespace Poc.TextProcessor.ResourceAccess.Repositories.Abstractions
{
    public interface ITextRepository
    {
        IEnumerable<Domains.Text> Get();
        Domains.Text Get(int id);
    }
}