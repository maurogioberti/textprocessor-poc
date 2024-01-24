using Poc.TextProcessor.Business.Logic.Abstractions.TextSort;

namespace Poc.TextProcessor.Business.Logic.TextSort
{
    /// <summary>
    /// Implements a sorting strategy that orders words alphabetically in descending order.
    /// This strategy arranges words starting from 'Z' to 'A', which can be useful for 
    /// displaying text in a reverse dictionary-like order or for prioritizing words
    /// that are later in the alphabet.
    /// </summary>
    public class AlphabeticDescendingSort : ITextSortingStrategy
    {
        public IEnumerable<string> Sort(IEnumerable<string> words) => words.OrderByDescending(x => x);
    }
}