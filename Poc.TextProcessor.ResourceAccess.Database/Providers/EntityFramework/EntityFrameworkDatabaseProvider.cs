using Microsoft.EntityFrameworkCore;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;
using System.Linq.Expressions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework
{
    public class EntityFrameworkDatabaseProvider(PocContext context) : IDatabaseProvider
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

        public int Execute(string sql, object parameters = null)
        {
            return _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
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

        public T Save<T>(T entity) where T : class
        {
            AddOrUpdate(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<T> SaveAsync<T>(T entity) where T : class
        {
            await AddOrUpdateAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        private void AddOrUpdate<T>(T entity) where T : class
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }
            entry.State = entry.IsKeySet ? EntityState.Modified : EntityState.Added;
        }

        private async Task AddOrUpdateAsync<T>(T entity) where T : class
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }
            entry.State = entry.IsKeySet ? EntityState.Modified : EntityState.Added;
            if (entry.State == EntityState.Added)
            {
                await _context.Set<T>().AddAsync(entity);
            }
        }
    }
}
