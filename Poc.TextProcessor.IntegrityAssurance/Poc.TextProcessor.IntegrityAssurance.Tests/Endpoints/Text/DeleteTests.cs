using Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Base;
using System.Net;

namespace Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Text
{
    public class DeleteTests : TestsBase
    {
        [Test]
        public async Task Delete_When_Id_Exists_Should_Return_NoContent()
        {
            var existingId = 10003;

            var deleteRequest = new RestRequest(Core.Settings.Endpoints.Text.DeleteEndpoint(existingId), Method.Delete);
            var deleteResponse = await _client.ExecuteAsync(deleteRequest);

            var getRequest = new RestRequest(Core.Settings.Endpoints.Text.GetEndpoint(existingId), Method.Get);
            var getResponse = await _client.ExecuteAsync<Core.Contracts.Text>(getRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That(getResponse.Data, Is.Null);
        }

        [Test]
        public async Task Delete_When_Invalid_Input_Should_Return_BadRequest()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.DeleteIdTooLongParametersEndpoint, Method.Delete);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task Delete_When_Invalid_Input_Should_Return_NotFound()
        {
            var request = new RestRequest(Core.Settings.Endpoints.Text.DeleteInvalidEndpoint, Method.Delete);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}