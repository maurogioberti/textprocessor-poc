using Poc.TextProcessor.IntegrityAssurance.Core.Contracts.Collections;
using Poc.TextProcessor.IntegrityAssurance.Core.Settings;
using Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Base;
using Poc.TextProcessor.IntegrityAssurance.Tests.Helpers;
using System.Net;

namespace Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Text
{
    public class GetTests : TestsBase
    {
        private const int ExpectedGetId = 10002;

        [Test]
        public async Task GetAll_When_Called_Should_Return_Ok()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.GetAll, Method.Get);
            var response = await _client.ExecuteAsync<TextCollection>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo(Headers.ContentType.ApplicationJson));
        }

        [Test]
        public async Task GetAll_When_Called_Should_Return_Inserted_Text()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.GetAll, Method.Get);
            var response = await _client.ExecuteAsync<TextCollection>(request);
            var textCollectionResponse = response.Data;

            var expectedTextContent = "Test Expected Result.";
            var expectedTextId = 10001;

            
            Assert.That(response.IsSuccessful);

            Assert.That(textCollectionResponse.Items.Any());

            var textItem = textCollectionResponse.Items.Single(x => x.Id == expectedTextId);

            ValidationHelper.AssertIntegrityScriptNotNull(textItem, expectedTextId);

            //Compare Expected Result
            Assert.That(textItem.Content, Is.EqualTo(expectedTextContent));
        }


        [Test]
        public async Task Get_When_Called_Should_Return_Ok()
        {
            var request = new RestRequest($"{Core.Settings.Endpoints.Text.Get(ExpectedGetId)}", Method.Get);
            var response = await _client.ExecuteAsync<TextCollection>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo(Headers.ContentType.ApplicationJson));
        }

        [Test]
        public async Task Get_When_Called_Should_Return_Inserted_Text()
        {
            var expectedTextContent = "Test Result for Get by Id.";

            var request = new RestRequest($"{Core.Settings.Endpoints.Text.Get(ExpectedGetId)}", Method.Get);
            var response = await _client.ExecuteAsync<Core.Contracts.Text>(request);
            var textItem = response.Data;

            Assert.That(response.IsSuccessful);

            ValidationHelper.AssertIntegrityScriptNotNull(textItem, ExpectedGetId);

            Assert.That(textItem.Content, Is.EqualTo(expectedTextContent));
        }
    }
}