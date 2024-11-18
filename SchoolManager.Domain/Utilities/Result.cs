namespace SchoolManager.Domain.Utilities;

public class Result<T>
{
    public T Value { get; private set; } = default!;
    public bool IsSuccess { get; private set; } = false;
    public List<string> Errors { get; private set; } = [];

    private Result(T value, bool isSuccess, List<string> errors)
    {
        Value = value;
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, []);
    }

    public static Result<T> Failure(params string[] errors)
    {
        return new Result<T>(default!, false, errors.ToList());
    }
}