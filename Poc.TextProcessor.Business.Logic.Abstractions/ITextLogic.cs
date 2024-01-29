using Poc.TextProcessor.ResourceAccess.Contracts;

namespace Poc.TextProcessor.Business.Logic.Abstractions
{
    public interface ITextLogic
    {
        Text Get(int id);
        Text GetRandom();
        Statistics GetStatistics(string textContent);
    }
}