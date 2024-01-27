using FluentValidation;

namespace CleanArchitect.Domain.Users;

public class UserValidator : AbstractValidator<User>
{
	public UserValidator()
	{
        RuleFor(user => user.FirstName).NotEmpty().MaximumLength(250);
        RuleFor(user => user.LastName).NotEmpty().MaximumLength(250);
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email can not be empty.")
            .EmailAddress().WithMessage("Email format not correct.");
        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password can not be empty.")
            .MinimumLength(8).WithMessage("Password length must be at least 8 characters.")
            .MaximumLength(16).WithMessage("Password length must not exceed 16 characters.")
            .Matches(@"[A-Z]+").WithMessage("Pasword should contain at least one uppercase character.")
            .Matches(@"[a-z]+").WithMessage("Pasword should contain at least one lowercase character.")
            .Matches(@"[0-9]+").WithMessage("Password should contain at least one number")
            .Matches(@"[\!\?\*\@\.]+").WithMessage("Password should contain one non alphanumerical character.");
    }
}
