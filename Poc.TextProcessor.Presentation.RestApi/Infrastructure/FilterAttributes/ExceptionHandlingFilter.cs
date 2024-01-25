using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Poc.TextProcessor.CrossCutting.Globalization;

namespace Poc.TextProcessor.Presentation.RestApi.Infrastructure.FilterAttributes
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            var methodInfo = (context.ActionDescriptor as ControllerActionDescriptor)?.MethodInfo;
            var responseOnExceptionAttribute = methodInfo?.GetCustomAttributes(typeof(ResponseOnExceptionAttribute), false).FirstOrDefault() as ResponseOnExceptionAttribute;

            if (responseOnExceptionAttribute != null && responseOnExceptionAttribute.ExceptionTypes.Contains(exceptionType))
            {
                context.Result = new ObjectResult(Messages.UnexpectedError)
                {
                    StatusCode = (int)responseOnExceptionAttribute.ResponseCode
                };
                context.ExceptionHandled = true;
            }
        }
    }
}