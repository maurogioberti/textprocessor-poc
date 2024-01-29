using System.Linq.Expressions;

namespace Poc.TextProcessor.ResourceAccess.Database.Abstractions
{
    public interface IDatabaseProvider
    {
        IEnumerable<T> Query<T>(string sql, object parameters = null) where T : class;
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null) where T : class;
        int Execute(string sql, object parameters = null);
        Task<int> ExecuteAsync(string sql, object parameters = null);
        IEnumerable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> Get<T>() where T : class;
        Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<IEnumerable<T>> GetAsync<T>() where T : class;
        T Save<T>(T entity) where T : class;
        Task<T> SaveAsync<T>(T entity) where T : class;
    }
}