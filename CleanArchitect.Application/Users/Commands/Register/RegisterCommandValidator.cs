using FluentValidation;

namespace CleanArchitect.Application.Users.Commands.RegisterUser;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname can not be empty.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("lastname can not be empty.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email address is not in correct format.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty.");
    }
}
