using Poc.TextProcessor.ResourceAccess.Contracts;

namespace Poc.TextProcessor.Services.Abstractions
{
    public interface ITextService
    {
        Text GetRandom();
        Statistics GetStatistics(string textContent);
    }
}