using Poc.TextProcessor.ResourceAccess.Contracts;

namespace Poc.TextProcessor.Business.Logic.Abstractions
{
    public interface ITextLogic
    {
        Text GetRandom();
        Statistics GetStatistics(string textContent);
    }
}