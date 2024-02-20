using Poc.TextProcessor.IntegrityAssurance.Core.Settings;
using Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Base;
using System.Net;

namespace Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Text
{
    public class OrderedTextTests : TestsBase
    {
        private const string AlphabeticAscendingOrder = "AlphabeticAsc";
        private const string AlphabeticDescendingOrder = "AlphabeticDesc";
        private const string LengthAscendingOrder = "LengthAsc";
        private const string NotExpectedOrder = "None";

        [TestCase(AlphabeticAscendingOrder)]
        [TestCase(AlphabeticDescendingOrder)]
        [TestCase(LengthAscendingOrder)]
        public async Task OrderedText_When_Called_Should_Return_Ok(string sortOption)
        {
            var text = _fixture.Create<string>();
            var request = new RestRequest(Core.Settings.Endpoints.Text.OrderedTextEndpoint(text, sortOption), Method.Get);
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

        [Test]
        public async Task OrderedText_When_Invalid_SortOption_Should_Return_InternalServerError()
        {
            var text = _fixture.Create<string>();
            var request = new RestRequest(Core.Settings.Endpoints.Text.OrderedTextEndpoint(text, NotExpectedOrder), Method.Get);
            var response = await _client.ExecuteAsync<string>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
    }
}