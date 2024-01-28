using CleanArchitect.Domain.Users;

namespace CleanArchitect.Application.Common.Services.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
