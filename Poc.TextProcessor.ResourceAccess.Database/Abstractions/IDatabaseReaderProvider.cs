using System.Linq.Expressions;

namespace Poc.TextProcessor.ResourceAccess.Database.Abstractions
{
    public interface IDatabaseReaderProvider
    {
        IEnumerable<T> Query<T>(string sql, object parameters = null) where T : class;
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null) where T : class;
        IEnumerable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> Get<T>() where T : class;
        Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<IEnumerable<T>> GetAsync<T>() where T : class;
    }
}