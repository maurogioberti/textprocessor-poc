namespace Poc.TextProcessor.ResourceAccess.Database
{
    public interface IDatabaseProvider
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null) where T : class;
        Task<int> ExecuteAsync(string sql, object parameters = null);
        Task<T> SaveAsync<T>(T entity) where T : class;
    }
}