using Poc.TextProcessor.CrossCutting.Utils.Constants;

namespace Poc.TextProcessor.Business.Logic.Base
{
    public class TextLogicBase
    {
        protected IEnumerable<string> SplitText(string textContent)
        {
            return textContent.Split(new[] { TextConstants.Space, TextConstants.CarriageReturn, TextConstants.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}