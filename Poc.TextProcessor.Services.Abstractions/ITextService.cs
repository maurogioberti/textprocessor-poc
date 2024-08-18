using Poc.TextProcessor.ResourceAccess.Contracts;
using Poc.TextProcessor.ResourceAccess.Contracts.Collections;

namespace Poc.TextProcessor.Services.Abstractions
{
    public interface ITextService
    {
        Text Get(int id);
        TextCollection Get();
        Text GetRandom();
        Statistics GetStatistics(string textContent);
    }
}