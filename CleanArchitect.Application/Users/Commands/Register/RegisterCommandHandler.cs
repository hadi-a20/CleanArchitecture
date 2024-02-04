using CleanArchitect.Application.Users.Dtos;
using CleanArchitect.Domain.Common.Models.Abstracts;
using CleanArchitect.Domain.Users;
using Mediator;
using CleanArchitect.Application.Common.Services.Authentication;
using UserErrors = CleanArchitect.Domain.Users.UserErrors;
using CommonErrors = CleanArchitect.Domain.Common;

namespace CleanArchitect.Application.Users.Commands.RegisterUser;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result<AuthenticationResultDto>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async ValueTask<Result<AuthenticationResultDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userRepository.UserWithMailExistsAsync(request.Email, cancellationToken);
        if (userExists.IsError)
        {
            return CommonErrors.BaseErrors.Error.Failure();
        }
        if (userExists.Value)
        {
            return UserErrors.Errors.User.DuplicateEmailError;
        }

        var user = User.Create(
            firstName: request.FirstName,
            lastName: request.LastName,
            email: request.Email,
            password: request.Password);
        if (user.IsError)
        {
            return user.Errors;
        }
        
        user = await _userRepository.AddAsync(user.Value, cancellationToken);
        if (!user.IsError)
        {
            var token = _jwtTokenGenerator.GenerateToken(user.Value);
            await Task.CompletedTask;
            return new AuthenticationResultDto(user.Value, token);
        }
        return user.Errors;
    }
}
