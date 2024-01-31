using Microsoft.AspNetCore.Mvc;
using Poc.TextProcessor.CrossCutting.Enums;
using Poc.TextProcessor.CrossCutting.Exceptions;
using Poc.TextProcessor.CrossCutting.Globalization;
using Poc.TextProcessor.CrossCutting.Utils.Constants;
using Poc.TextProcessor.Presentation.RestApi.Infrastructure.FilterAttributes;
using Poc.TextProcessor.ResourceAccess.Contracts;
using Poc.TextProcessor.ResourceAccess.Contracts.Collections;
using Poc.TextProcessor.Services.Abstractions;
using System.Net;

namespace Poc.TextProcessor.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextController(ITextService textService, ITextSortService textSortService) : ControllerBase
    {
        private readonly ITextService _textService = textService;
        private readonly ITextSortService _textSortService = textSortService;

        [HttpGet("Options")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SortCollection))]
        public IActionResult GetOptions()
        {
            var sortOptions = _textSortService.List();
            return Ok(sortOptions);
        }

        [HttpGet("Statistics")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Statistics))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetStatistics([FromQuery] string textToAnalyze)
        {
            var textStatics = _textService.GetStatistics(textToAnalyze);
            return Ok(textStatics);
        }

        [HttpGet("OrderedText")]
        [Produces("application/json", "application/xml")]
        [ResponseOnException(HttpStatusCode.InternalServerError, typeof(SortingException))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOrderedText([FromQuery] string textToOrder, string orderOption)
        {
            if (Enum.TryParse(orderOption, true, out SortOption orderOptionEnum))
            {
                var sortedText = _textSortService.Sort(textToOrder, orderOptionEnum);
                return Ok(sortedText);
            }

            var validOptions = string.Join($"{TextConstants.Comma}{TextConstants.Space}", Enum.GetNames(typeof(SortOption)));
            return BadRequest($"{Messages.InvalidOrderOption}{TextConstants.Space}{validOptions}{TextConstants.Period}");
        }
    }
}