using Microsoft.EntityFrameworkCore;

namespace Poc.TextProcessor.ResourceAccess.Database.EntityFramework
{
    public class EntityFrameworkDatabaseProvider : IDatabaseProvider
    {
        private readonly DbContext _context;

        public EntityFrameworkDatabaseProvider(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
            where T : class
        {
            return await _context.Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(sql, parameters);
            return result;
        }

        public async Task<T> SaveAsync<T>(T entity) where T : class
        {
            var dbSet = _context.Set<T>();
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            if (entry.IsKeySet)
            {
                entry.State = EntityState.Modified;
            }
            else
            {
                await dbSet.AddAsync(entity);
            }

            await _context.SaveChangesAsync();
            return entity;
        }
    }
}