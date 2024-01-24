using Poc.TextProcessor.Business.Logic.Abstractions.TextSort;

namespace Poc.TextProcessor.Business.Logic.TextSort
{
    /// <summary>
    /// Implements a sorting strategy that orders words based on their length in ascending order.
    /// If multiple words have the same length, they are further sorted alphabetically.
    /// This strategy is useful when you want to prioritize shorter words, while still maintaining
    /// an alphabetical order for words of the same length.
    /// </summary>
    public class LengthAscendingSort : ITextSortingStrategy
    {
        public IEnumerable<string> Sort(IEnumerable<string> words) => words.OrderBy(x => x.Length).ThenBy(x => x);
    }
}