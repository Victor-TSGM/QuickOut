namespace QuickOut.Library
{
    public interface IRepository<T>
    {
        Task<T?> GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
