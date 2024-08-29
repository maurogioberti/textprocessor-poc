using Microsoft.EntityFrameworkCore;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework
{
    public class EntityFrameworkWriterProvider(PocContext context) : IDatabaseWriterProvider
    {
        private readonly PocContext _context = context;

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

        public void Remove<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task RemoveAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
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