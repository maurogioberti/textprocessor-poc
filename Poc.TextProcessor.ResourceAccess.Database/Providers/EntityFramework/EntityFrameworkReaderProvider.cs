using Microsoft.EntityFrameworkCore;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;
using System.Linq.Expressions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework
{
    public class EntityFrameworkReaderProvider(PocContext context) : IDatabaseReaderProvider
    {
        private readonly PocContext _context = context;

        public IEnumerable<T> Query<T>(string sql, object parameters = null) where T : class
        {
            return _context.Set<T>().FromSqlRaw(sql, parameters).ToList();
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null) where T : class
        {
            return await _context.Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
        }

        public IEnumerable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> Get<T>() where T : class
        {
            return _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
