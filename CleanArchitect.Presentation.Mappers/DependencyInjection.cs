using CleanArchitect.Presentation.Mappers.Users;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitect.Presentation.Mappers;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetAssembly(typeof(UserMappingConfigs)));
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
