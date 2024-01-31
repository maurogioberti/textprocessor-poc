using Poc.TextProcessor.IntegrityAssurance.Core.Contracts;
using Poc.TextProcessor.IntegrityAssurance.Core.Settings;
using Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Base;
using System.Net;

namespace Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Text
{
    public class StatiticsTests : TestsBase
    {
        [Test]
        public async Task Statitics_When_Called_Should_Return_Ok()
        {
            var text = _fixture.Create<string>();
            var request = new RestRequest(Core.Settings.Endpoints.Text.StatisticsEndpoint(text), Method.Get);
            var response = await _client.ExecuteAsync<Statistics>(request);
            var statitics = response.Data;

            Assert.That(statitics, Is.Not.Null);
            Assert.That(response.ContentType, Is.EqualTo(Headers.ContentType.ApplicationJson));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Statitics_When_Invalid_Input_Should_Return_BadRequest()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.StatisticsNoParametersEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task Statitics_When_Invalid_Input_Should_Return_NotFound()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.StatisticsInvalidEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}