namespace QuickOut.Library;

public interface ICacheStore {
    public Task<T> GetOrAdd<T>(ICacheKey key, Func<Task<T>> insertAction, int expirationSeconds = 600);
}