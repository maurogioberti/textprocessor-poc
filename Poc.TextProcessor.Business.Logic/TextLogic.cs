using AutoFixture;
using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.Business.Logic.Base;
using Poc.TextProcessor.CrossCutting.Utils.Constants;
using Poc.TextProcessor.ResourceAccess.Contracts;
using Poc.TextProcessor.ResourceAccess.Mappers;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;

namespace Poc.TextProcessor.Business.Logic
{
    public class TextLogic(ITextRepository textRepository, ITextMapper textMapper) : TextLogicBase, ITextLogic
    {
        private readonly ITextRepository _textRepository = textRepository;
        private readonly ITextMapper _textMapper = textMapper;
        private readonly Fixture _fixture = new();

        public Text Get(int id)
        {
            var textDomain = _textRepository.Get(id);
            return _textMapper.Map(textDomain);
        }

        public Text GetRandom()
        {
            Random random = new Random();
            var randomLength = random.Next(5, 120);
            var longString = string.Join(TextConstants.Space, _fixture.CreateMany<string>(randomLength));

            return _fixture
                    .Build<Text>()
                    .With(x => x.Id)
                    .With(x => x.Content, longString)
                    .Create();
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