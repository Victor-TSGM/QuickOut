namespace QuickOut.Library;

public class Result
{
    public bool Succeeded { get; protected set; }
    public List<string> Messages { get; set; } = new();

    protected Result() { }

    public void AddMessage(string message) => Messages.Add(message);

    public static Result Fail() => new Result { Succeeded = false };
    public static Result Fail(params string[] message) => new Result { Succeeded = false, Messages = message.ToList() };
    public static Result Fail(List<string> messages) => new Result { Succeeded = false, Messages = messages };

    public static Result Success() => new Result { Succeeded = true };
    public static Result Success(params string[] message) => new Result { Succeeded = false, Messages = message.ToList() };
    public static Result Success(List<string> messages) => new Result { Succeeded = false, Messages = messages };
}

public class Result<T> : Result
{
    public T Data { get; protected set; }

    public new static Result<T> Fail() => new Result<T> { Succeeded = false };
    public new static Result<T> Fail(params string[] messages) => new Result<T> { Succeeded = false, Messages = messages.ToList() };
    public new static Result<T> Fail(List<string> messages) => new Result<T> { Succeeded = false, Messages = messages };

    public static Result<T> Success(T data) => new Result<T> { Succeeded = true, Data = data };
    public static Result Success(T data, params string[] message) => new Result<T> { Succeeded = true, Data = data, Messages = message.ToList() };
    public static Result<T> Success(T data, List<string> messages) => new Result<T> { Succeeded = true, Data = data, Messages = messages };
}

public static class ResultExtensions
{
    public static Task<Result> AsTask(this Result result) => Task.FromResult(result);
    public static Task<Result<T>> AsTask<T>(this Result<T> result) => Task.FromResult(result);
}
public static class ResultHelpers
{
    public static bool IsAnyFailed(params Result[] results)
    {
        foreach (Result? result in results)
        {
            if (!result.Succeeded) return true;
        }

        return false;
    }

    public static List<string> JoinResultMessages(params Result[] results)
    {
        List<string> messages = new();

        foreach (Result? result in results)
        {
            messages.AddRange(result.Messages);
        }

        return messages;
    }

    public static Result FailWithMessages(params Result[] results)
    {
        return Result.Fail(JoinResultMessages(results));
    }
}
