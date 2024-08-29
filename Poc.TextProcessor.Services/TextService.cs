using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.ResourceAccess.Contracts;
using Poc.TextProcessor.ResourceAccess.Contracts.Collections;
using Poc.TextProcessor.Services.Abstractions;
using Poc.TextProcessor.Services.Base;

namespace Poc.TextProcessor.Services
{
    public class TextService(ITextLogic textLogic) : ServiceBase, ITextService
    {
        private readonly ITextLogic _textLogic = textLogic;

        public Text Get(int id)
        {
            try
            {
                return _textLogic.Get(id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception e)
            {
                HandleException(e);
            }

            return null;
        }

        public void Remove(int id)
        {
            try
            {
                _textLogic.Remove(id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }

        public TextCollection Get()
        {
            try
            {
                return _textLogic.Get();
            }
            catch (Exception e)
            {
                HandleException(e);
            }

            return null;
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