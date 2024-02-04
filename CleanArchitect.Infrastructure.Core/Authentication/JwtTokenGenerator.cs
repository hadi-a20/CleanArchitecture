using CleanArchitect.Application.Common.Services.Authentication;
using CleanArchitect.Domain.Users;

namespace CleanArchitect.Infrastructure.Core.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        return "token";
    }
}
