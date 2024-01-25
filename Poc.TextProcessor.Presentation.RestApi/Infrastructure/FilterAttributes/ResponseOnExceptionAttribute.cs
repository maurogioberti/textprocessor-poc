using System.Net;

namespace Poc.TextProcessor.Presentation.RestApi.Infrastructure.FilterAttributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ResponseOnExceptionAttribute : Attribute
    {
        public Type[] ExceptionTypes { get; private set; }
        public HttpStatusCode ResponseCode { get; private set; }

        public ResponseOnExceptionAttribute(HttpStatusCode responseCode, params Type[] exceptionTypes)
        {
            ResponseCode = responseCode;
            ExceptionTypes = exceptionTypes;
        }
    }
}