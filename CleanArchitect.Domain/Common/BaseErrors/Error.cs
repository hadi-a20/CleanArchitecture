namespace CleanArchitect.Domain.Common.BaseErrors;

public readonly struct Error
{
    public string Code { get; }
    public ErrorType Type { get; }
    public string Description { get; }

    private Error(string code, ErrorType type, string description)
    {
        Code = code;
        Type = type;
        Description = description;
    }

    public static Error Failure(
        string code = "General.Failure",
        string description = "A failure has occurred.") =>
        new(code, ErrorType.Failure, description);

    public static Error Unexpected(
        string code = "General.Unexpected",
        string description = "An unexpected error has occurred.") =>
        new(code, ErrorType.Unexpected, description);

    public static Error Validation(
        string code = "General.Validation",
        string description = "A validation error has occurred.") =>
        new(code, ErrorType.Validation, description);

    public static Error Conflict(
        string code = "General.Conflict",
        string description = "A conflict error has occurred.") =>
        new(code, ErrorType.Conflict, description);

    public static Error NotFound(
        string code = "General.NotFound",
        string description = "A 'Not Found' error has occurred.") =>
        new(code, ErrorType.NotFound, description);
}