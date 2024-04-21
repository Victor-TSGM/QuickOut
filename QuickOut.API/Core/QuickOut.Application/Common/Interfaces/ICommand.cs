namespace QuickOut.Application.Common
{
    public interface IRequestBase { }

    public interface ICommand<TResponse> : IRequestBase
    {
        
    }
}
