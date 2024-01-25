using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.CrossCutting.Enums;
using Poc.TextProcessor.ResourceAccess.Contracts.Collections;
using Poc.TextProcessor.Services.Abstractions;
using Poc.TextProcessor.Services.Base;

namespace Poc.TextProcessor.Services
{
    public class TextSortService : ServiceBase, ITextSortService
    {
        private readonly ITextSortLogic _textSortLogic;

        public TextSortService(ITextSortLogic textSortLogic)
        {
            _textSortLogic = textSortLogic;
        }

        public SortCollection List()
        {
            try
            {
                return _textSortLogic.List();
            }
            catch (Exception e)
            {
                HandleException(e);
            }

            return null;
        }

        public string Sort(string textSortContent, SortOption orderOption)
        {
            try
            {
                return _textSortLogic.Sort(textSortContent, orderOption);
            }
            catch (Exception e)
            {
                HandleException(e);
            }

            return null;
        }
    }
}