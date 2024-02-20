using NHibernate;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.NHibernate
{
    public class NHibernateWriterProvider(ISessionFactory sessionFactory) : IDatabaseWriterProvider
    {
        private readonly ISessionFactory _sessionFactory = sessionFactory;

        public T Save<T>(T entity) where T : class
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(entity);
                transaction.Commit();
                return entity;
            }
        }

        public async Task<T> SaveAsync<T>(T entity) where T : class
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                await session.SaveOrUpdateAsync(entity);
                await transaction.CommitAsync();
                return entity;
            }
        }
    }
}