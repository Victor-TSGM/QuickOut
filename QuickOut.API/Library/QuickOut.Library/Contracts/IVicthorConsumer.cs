namespace QuickOut.Library
{
    public interface IVicthorConsumer<T>
    {
        Task<Result> Handle(T parameters);
    }
}
