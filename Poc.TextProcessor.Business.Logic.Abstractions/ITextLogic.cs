using Poc.TextProcessor.ResourceAccess.Contracts;
using Poc.TextProcessor.ResourceAccess.Contracts.Collections;

namespace Poc.TextProcessor.Business.Logic.Abstractions
{
    public interface ITextLogic
    {
        TextCollection Get();
        Text Get(int id);
        Text GetRandom();
        Statistics GetStatistics(string textContent);
    }
}