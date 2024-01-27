using CleanArchitect.Domain.Common.BaseErrors;

namespace CleanArchitect.Domain.Common.Models.Abstracts;

public record struct Result<TValue> : IResult
{
    private readonly TValue? _value = default;
    private readonly List<Error>? _errors = null;

    private static readonly Error NoErrors = Error.Unexpected(
        code: "Result.NoErrors",
        description: "Error list cannot be retrieved from a successful Result.");

    public bool IsError { get; }

    public List<Error> Errors => IsError ? _errors! : new List<Error> { NoErrors };

    public static Result<TValue> From(List<Error> errors)
    {
        return errors;
    }

    public TValue Value => _value!;

    private Result(Error error)
    {
        _errors = new List<Error> { error };
        IsError = true;
    }

    private Result(List<Error> errors)
    {
        _errors = errors;
        IsError = true;
    }

    private Result(TValue value)
    {
        _value = value;
        IsError = false;
    }

    public static implicit operator Result<TValue>(TValue value)
    {
        return new Result<TValue>(value);
    }

    public static implicit operator Result<TValue>(Error error)
    {
        return new Result<TValue>(error);
    }

    public static implicit operator Result<TValue>(List<Error> errors)
    {
        return new Result<TValue>(errors);
    }

    public static implicit operator Result<TValue>(Error[] errors)
    {
        return new Result<TValue>(errors.ToList());
    }

    public TResult Match<TResult>(Func<TValue, TResult> onValue, Func<List<Error>, TResult> onError)
    {
        if (IsError)
        {
            return onError(Errors);
        }

        return onValue(Value);
    }
}