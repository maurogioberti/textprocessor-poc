namespace Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints.Base
{
    public class TestsBase()
    {
        protected readonly RestClient _client = new(Core.Settings.Endpoints.BaseUrl);
    }
}