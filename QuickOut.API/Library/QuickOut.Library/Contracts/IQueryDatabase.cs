namespace QuickOut.Library
{
    public interface IQueryDatabase
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, new();
    }
}
