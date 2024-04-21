namespace QuickOut.Application.Common
{
    public interface IQueryDatabase
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, new();
    }
}
