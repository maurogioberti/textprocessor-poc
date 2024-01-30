using Poc.TextProcessor.IntegrityAssurance.Core.Settings;
using Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Base;
using System.Net;

namespace Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Text
{
    public class OrderedTextTests : TestsBase
    {
        private const string TextToOrder = "abced a b c";

        [TestCase("AlphabeticAsc")]
        [TestCase("AlphabeticDesc")]
        [TestCase("LengthAsc")]
        public async Task OrderedText_When_Called_Should_Return_Ok(string orderOption)
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.OrderedTextEndpoint(TextToOrder, orderOption), Method.Get);
            var response = await _client.ExecuteAsync<string>(request);
            var orderedText = response.Data;

            Assert.That(orderedText, Is.Not.Empty);
            Assert.That(response.ContentType, Is.EqualTo(Headers.ContentType.ApplicationJson));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task OrderedText_When_Invalid_Input_Should_Return_BadRequest()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.OrderedTextBadRequestEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task OrderedText_When_Invalid_Input_Should_Return_NotFound()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.OrderedTextInvalidEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}