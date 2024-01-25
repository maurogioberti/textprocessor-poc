using Poc.TextProcessor.CrossCutting.Enums;
using Poc.TextProcessor.ResourceAccess.Contracts.Collections;

namespace Poc.TextProcessor.Services.Abstractions
{
    public interface ITextSortService
    {
        SortCollection List();
        string Sort(string textContent, SortOption orderOption);
    }
}