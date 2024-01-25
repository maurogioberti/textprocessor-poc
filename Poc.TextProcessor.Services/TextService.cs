using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.ResourceAccess.Contracts;
using Poc.TextProcessor.Services.Abstractions;
using Poc.TextProcessor.Services.Base;

namespace Poc.TextProcessor.Services
{
    public class TextService : ServiceBase, ITextService
    {
        private readonly ITextLogic _textLogic;

        public TextService(ITextLogic textLogic)
        {
            _textLogic = textLogic;
        }

        public Text GetRandom()
        {
            try
            {
                return _textLogic.GetRandom();
            }
            catch (Exception e)
            {
                HandleException(e);
            }

            return null;
        }

        public Statistics GetStatistics(string textContent)
        {
            try
            {
                return _textLogic.GetStatistics(textContent);
            }
            catch (Exception e)
            {
                HandleException(e);
            }

            return null;
        }
    }
}