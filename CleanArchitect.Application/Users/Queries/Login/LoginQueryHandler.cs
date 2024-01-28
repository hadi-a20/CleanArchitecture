using CleanArchitect.Application.Common.Services.Authentication;
using CleanArchitect.Application.Users.Dtos;
using CleanArchitect.Domain.Common.Models.Abstracts;
using CleanArchitect.Domain.Users;
using CleanArchitect.Domain.Users.UserErrors;
using Mediator;

namespace CleanArchitect.Application.Users.Queries.Login;

internal class LoginQueryHandler : IQueryHandler<LoginQuery, Result<AuthenticationResultDto>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async ValueTask<Result<AuthenticationResultDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user.IsError)
        {
            return Errors.User.InvalidCredentials;
        }

        if (user.Value.Password != request.Password)
        {
            return Errors.User.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Value);
        await Task.CompletedTask;
        return new AuthenticationResultDto(user.Value, token);
    }
}
