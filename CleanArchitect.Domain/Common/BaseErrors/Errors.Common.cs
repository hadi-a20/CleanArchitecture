using CleanArchitect.Domain.Common.BaseErrors;

namespace CleanArchitect.Domain.Common;

public static partial class Errors
{
    public static class Common
    {
        public static Error ObjectNotFound => Error.NotFound(
            nameof(ObjectNotFound),
            "Object does not exist.");
    }
}