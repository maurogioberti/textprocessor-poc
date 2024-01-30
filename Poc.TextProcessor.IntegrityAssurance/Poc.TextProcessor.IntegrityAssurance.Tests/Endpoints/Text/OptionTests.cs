using Poc.TextProcessor.IntegrityAssurance.Core.Contracts.Collections;
using Poc.TextProcessor.IntegrityAssurance.Core.Settings;
using Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Base;
using System.Net;

namespace Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Text
{
    public class OptionTests : TestsBase
    {
        [Test]
        public async Task SortOptions_When_Called_Should_Return_Ok()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.OptionsEndpoint, Method.Get);
            var response = await _client.ExecuteAsync<SortCollection>(request);
            var sortCollection = response.Data;

            Assert.That(sortCollection.Items, Is.Not.Empty);
            Assert.That(response.ContentType, Is.EqualTo(Headers.ContentType.ApplicationJson));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task SortOptions_When_Invalid_Input_Should_Return_NotFound()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.OptionsInvalidEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}