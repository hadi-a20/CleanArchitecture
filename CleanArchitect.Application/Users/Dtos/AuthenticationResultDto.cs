using CleanArchitect.Domain.Users;

namespace CleanArchitect.Application.Users.Dtos;

public record AuthenticationResultDto
{
    public User User { get; set; }
    public string Token { get; set; }

    public AuthenticationResultDto(User user, string token)
    {
        User = user;
        Token = token;
    }
}