using Poc.TextProcessor.IntegrityAssurance.Core.Settings;

namespace Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Base
{
    public class TestsBase()
    {
        protected readonly RestClient _client = new(ConfigurationFile.Instance.BaseUrl);
        protected readonly Fixture _fixture = new();
    }
}