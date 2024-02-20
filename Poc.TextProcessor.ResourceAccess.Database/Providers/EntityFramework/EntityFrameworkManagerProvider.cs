using Microsoft.EntityFrameworkCore;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;
using System.Linq.Expressions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework
{
    public class EntityFrameworkManagerProvider(PocContext context, IDatabaseReaderProvider readerProvider, IDatabaseWriterProvider writerProvider) : IDatabaseManagerProvider
    {
        private readonly PocContext _context = context;
        private readonly IDatabaseReaderProvider _readerProvider = readerProvider;
        private readonly IDatabaseWriterProvider _writerProvider = writerProvider;

        #region IDatabaseReaderProvider implementation
        public IEnumerable<T> Query<T>(string sql, object parameters = null) where T : class
        {
            return _readerProvider.Query<T>(sql, parameters);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null) where T : class
        {
            return await _readerProvider.QueryAsync<T>(sql, parameters);
        }

        public IEnumerable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _readerProvider.Get<T>(predicate);
        }

        public IEnumerable<T> Get<T>() where T : class
        {
            return _readerProvider.Get<T>();
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _readerProvider.GetAsync<T>(predicate);
        }

        public async Task<IEnumerable<T>> GetAsync<T>() where T : class
        {
            return await _readerProvider.GetAsync<T>();
        }
        #endregion

        #region IDatabaseWriterProvider implementation
        public T Save<T>(T entity) where T : class
        {
            return _writerProvider.Save<T>(entity);
        }

        public async Task<T> SaveAsync<T>(T entity) where T : class
        {
            return await _writerProvider.SaveAsync<T>(entity);
        }
        #endregion

        public int Execute(string sql, object parameters = null)
        {
            return _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}