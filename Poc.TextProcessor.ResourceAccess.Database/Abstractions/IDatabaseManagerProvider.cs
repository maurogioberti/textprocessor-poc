namespace Poc.TextProcessor.ResourceAccess.Database.Abstractions
{
    public interface IDatabaseManagerProvider : IDatabaseReaderProvider, IDatabaseWriterProvider
    {
        int Execute(string sql, object parameters = null);
        Task<int> ExecuteAsync(string sql, object parameters = null);
    }
}