using Poc.TextProcessor.Business.Logic.Abstractions.TextSort;

namespace Poc.TextProcessor.Business.Logic.TextSort
{
    /// <summary>
    /// Implements a sorting strategy that orders words alphabetically in ascending order.
    /// This strategy arranges words starting from 'A' to 'Z', making it useful for 
    /// displaying text in a standard dictionary-like alphabetical order.
    /// </summary>
    public class AlphabeticAscendingSort : ITextSortingStrategy
    {
        public IEnumerable<string> Sort(IEnumerable<string> words) => words.OrderBy(x => x);
    }
}