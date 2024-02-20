using NHibernate;
using NHibernate.Linq;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;
using System.Linq.Expressions;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.NHibernate
{
    public class NHibernateReaderProvider(ISessionFactory sessionFactory) : IDatabaseReaderProvider
    {
        private readonly ISessionFactory _sessionFactory = sessionFactory;

        public IEnumerable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Query<T>().Where(predicate).ToList();
            }
        }

        public IEnumerable<T> Get<T>() where T : class
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return await session.Query<T>().Where(predicate).ToListAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAsync<T>() where T : class
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return await session.Query<T>().ToListAsync();
            }
        }

        public IEnumerable<T> Query<T>(string sql, object parameters = null) where T : class
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var query = session.CreateSQLQuery(sql);
                if (parameters != null)
                {
                    var paramsDictionary = parameters as Dictionary<string, object>;
                    foreach (var param in paramsDictionary)
                    {
                        query.SetParameter(param.Key, param.Value);
                    }
                }
                return query.List<T>();
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null) where T : class
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var query = session.CreateSQLQuery(sql);
                if (parameters != null)
                {
                    var paramsDictionary = parameters as Dictionary<string, object>;
                    foreach (var param in paramsDictionary)
                    {
                        query.SetParameter(param.Key, param.Value);
                    }
                }

                return await Task.FromResult(query.List<T>());
            }
        }
    }
}