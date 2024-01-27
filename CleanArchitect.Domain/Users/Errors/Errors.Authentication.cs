using CleanArchitect.Domain.Common.BaseErrors;

namespace CleanArchitect.Domain.Users.UserErrors;

public static partial class Errors
{
    public static class User
    {
        public static Error InvalidCredentials => Error.NotFound(
            nameof(InvalidCredentials),
            "Invalid crdentials.");

        public static Error DuplicateEmailError => Error.Conflict(
            nameof(DuplicateEmailError),
            "Email already exists.");
    }
}
