using Poc.TextProcessor.CrossCutting.Enums;
using Poc.TextProcessor.ResourceAccess.Contracts.Collections;

namespace Poc.TextProcessor.Business.Logic.Abstractions
{
    public interface ITextSortLogic
    {
        SortCollection List();
        string Sort(string textContent, SortOption orderOption);
    }
}