using FluentValidation;

namespace CleanArchitect.Application.Users.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email can not be empty.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty.");
    }
}
