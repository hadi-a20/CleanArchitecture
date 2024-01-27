using CleanArchitect.Domain.Common.BaseErrors;
using CleanArchitect.Domain.Common.Models.Abstracts;

namespace CleanArchitect.Domain.Users;

public sealed class User : RootEntity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public DateTimeOffset? LastpasswordUpdateDate { get; private set; }

    private User(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static Result<User> Create(string firstName, string lastName, string email, string password)
    {
        var user = new User(firstName, lastName, email, password);
        return ValidateUser(user);
    }

    private static Result<User> ValidateUser(User user)
    {
        UserValidator validator = new();
        var validationResult = validator.Validate(user);
        if (validationResult.IsValid)
        {
            return user;
        }
        return validationResult
            .Errors
            .ConvertAll(c => Error.Validation(c.PropertyName, c.ErrorMessage));
    }

    public void UpdatePassword(string newPassword)
    {
        Password = newPassword;
        LastpasswordUpdateDate = DateTimeOffset.Now;
    }
}
