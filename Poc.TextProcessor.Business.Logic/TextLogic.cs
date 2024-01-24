using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.Business.Logic.Base;
using Poc.TextProcessor.CrossCutting.Utils.Constants;
using Poc.TextProcessor.ResourceAccess.Contracts;
using Poc.TextProcessor.ResourceAccess.Mappers;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;

namespace Poc.TextProcessor.Business.Logic
{
    public class TextLogic : TextLogicBase, ITextLogic
    {
        private readonly ITextRepository _textRepository;
        private readonly ITextMapper _textMapper;

        public TextLogic(ITextRepository textRepository,
            ITextMapper textMapper)
        {
            _textRepository = textRepository;
            _textMapper = textMapper;
        }

        public Text GetRandom()
        {
            var random = new Random();
            var randomInteger = random.Next(0, 100);
            var textDomain = _textRepository.Get(randomInteger);

            return _textMapper.Map(textDomain);
        }

        public Statistics GetStatistics(string textContent)
        {
            var words = SplitText(textContent);

            var hyphenCount = textContent.Count(c => c == TextConstants.Hyphen);
            var wordCount = words.Count(word => word.Any(char.IsLetter));
            var spaceCount = textContent.Count(char.IsWhiteSpace);

            return new Statistics
            {
                Hypens = hyphenCount,
                Words = wordCount,
                Spaces = spaceCount
            };
        }
    }
}