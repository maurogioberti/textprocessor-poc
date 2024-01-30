using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.Business.Logic.Abstractions.TextSort;
using Poc.TextProcessor.Business.Logic.Base;
using Poc.TextProcessor.Business.Logic.TextSort;
using Poc.TextProcessor.CrossCutting.Enums;
using Poc.TextProcessor.CrossCutting.Exceptions;
using Poc.TextProcessor.CrossCutting.Globalization;
using Poc.TextProcessor.ResourceAccess.Contracts.Collections;
using Poc.TextProcessor.ResourceAccess.Mappers;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;

namespace Poc.TextProcessor.Business.Logic
{
    public class TextSortLogic(ITextSortRepository textSortRepository, ITextSortMapper textSortMapper) : TextLogicBase, ITextSortLogic
    {
        private readonly ITextSortRepository _textSortRepository = textSortRepository;
        private readonly ITextSortMapper _textSortMapper = textSortMapper;
        private readonly Dictionary<SortOption, ITextSortingStrategy> sortingStrategies = new()
        {
            { SortOption.AlphabeticAsc, new AlphabeticAscendingSort() },
            { SortOption.AlphabeticDesc, new AlphabeticDescendingSort() },
            { SortOption.LengthAsc, new LengthAscendingSort() },
        };

        public SortCollection List()
        {
            var textSortDomains = _textSortRepository.List();
            return _textSortMapper.MapCollection(textSortDomains);
        }

        public string Sort(string textContent, SortOption orderOption)
        {
            if (sortingStrategies.TryGetValue(orderOption, out var textSortingStrategy))
            {
                var words = SplitText(textContent);
                return textSortingStrategy.SortedContent(words);
            }

            throw new SortingException(Messages.InvalidOrderOption);
        }
    }
}