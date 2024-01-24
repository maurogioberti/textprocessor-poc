using Poc.TextProcessor.CrossCutting.Enums;
using Poc.TextProcessor.ResourceAccess.Domains;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Repositories
{
    public class TextSortRepository : ITextSortRepository
    {
        // TODO: Currently, this method generates a list of sort options directly from the SortOption enum.
        // This approach serves as a representative example for the technical exercise.
        // In a real-world scenario, this data might come from a database or a configuration file.

        public IEnumerable<TextSort> List()
        {
            return Enum
                    .GetValues(typeof(SortOption))
                    .Cast<SortOption>()
                    .Select((option, index) => new TextSort
                    {
                        Id = index,
                        Option = option
                    })
                    .ToList();
        }
    }
}