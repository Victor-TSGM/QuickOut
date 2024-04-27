using QuickOut.Library;

namespace QuickOut.Infrastructure.Common
{
    public class QueryDatabase : IQueryDatabase
    {
        private readonly QuickOutContext _appContext;
        public QueryDatabase(QuickOutContext appContext)
        {
            _appContext = appContext;
        }
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, new()
        {
            return _appContext.Set<TEntity>();
        }
    }
}