using Poc.TextProcessor.CrossCutting.Globalization;
using Poc.TextProcessor.CrossCutting.Logging;

namespace Poc.TextProcessor.Services.Base
{
    public class ServiceBase
    {
        protected void HandleException(Exception exception) => Logging.LogError(exception, Messages.UnexpectedExceptionError);
    }
}