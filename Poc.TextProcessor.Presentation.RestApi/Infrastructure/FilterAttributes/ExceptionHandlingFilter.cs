using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Poc.TextProcessor.CrossCutting.Globalization;
using System.Text;

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
                var responseContent = HandleExceptionResponse(context.Exception.Message);
                context.Result = new ObjectResult(responseContent)
                {
                    StatusCode = (int)responseOnExceptionAttribute.ResponseCode
                };
                context.ExceptionHandled = true;
            }
        }

        private static string HandleExceptionResponse(string exceptionMessage)
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.AppendLine(Messages.UnexpectedError);
            messageBuilder.AppendLine(exceptionMessage);

            return messageBuilder.ToString();
        }
    }
}