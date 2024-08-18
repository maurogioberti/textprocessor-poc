namespace Poc.TextProcessor.ResourceAccess.Database.Abstractions
{
    public interface IDatabaseWriterProvider
    {
        T Save<T>(T entity) where T : class;
        Task<T> SaveAsync<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        Task RemoveAsync<T>(T entity) where T : class;
    }
}