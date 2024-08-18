using Poc.TextProcessor.IntegrityAssurance.Core.Contracts.Collections;
using Poc.TextProcessor.IntegrityAssurance.Core.Settings;
using Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Base;
using Poc.TextProcessor.IntegrityAssurance.Tests.Helpers;
using System.Net;

namespace Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Text
{
    public class DeleteTests : TestsBase
    {
        [Test]
        public async Task Delete_When_Id_Exists_Should_Return_NoContent()
        {
            var existingId = 10003;

            var deleteRequest = new RestRequest(Core.Settings.Endpoints.Text.Delete(existingId), Method.Delete);
            var deleteResponse = await _client.ExecuteAsync(deleteRequest);
            var getRequest = new RestRequest(Core.Settings.Endpoints.Text.Get(existingId), Method.Get);
            var getResponse = await _client.ExecuteAsync<Core.Contracts.Text>(getRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That(getResponse.Data, Is.Null);
        }
    }
}