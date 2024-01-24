using Poc.TextProcessor.ResourceAccess.Domains;

namespace Poc.TextProcessor.ResourceAccess.Repositories.Abstractions
{
    public interface ITextSortRepository
    {
        IEnumerable<TextSort> List();
    }
}