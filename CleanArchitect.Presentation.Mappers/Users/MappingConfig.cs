using CleanArchitect.Application.Users.Dtos;
using CleanArchitect.Presentation.Contracts.Users.Responses;
using Mapster;

namespace CleanArchitect.Presentation.Mappers.Users;

public class UserMappingConfigs
{
    private readonly TypeAdapterConfig _config;

    public UserMappingConfigs(TypeAdapterConfig config)
    {
        _config = config;
    }

    public void Register()
    {
        _config.NewConfig<AuthenticationResultDto, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}
