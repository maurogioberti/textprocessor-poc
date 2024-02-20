using NHibernate;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;
using System.Linq.Expressions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.NHibernate
{
    public class NHibernateManagerProvider(ISessionFactory sessionFactory, IDatabaseReaderProvider readerProvider, IDatabaseWriterProvider writerProvider) : IDatabaseManagerProvider
    {
        private readonly ISessionFactory _sessionFactory = sessionFactory;
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
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var query = session.CreateSQLQuery(sql);
                SetParameters(query, parameters);
                var result = query.ExecuteUpdate();
                transaction.Commit();
                return result;
            }
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var query = session.CreateSQLQuery(sql);
                SetParameters(query, parameters);
                var result = await query.ExecuteUpdateAsync();
                await transaction.CommitAsync();
                return result;
            }
        }

        private static void SetParameters(IQuery query, object parameters)
        {
            if (parameters is IDictionary<string, object> paramsDict)
            {
                foreach (var param in paramsDict)
                {
                    query.SetParameter(param.Key, param.Value);
                }
            }
        }
    }
}
