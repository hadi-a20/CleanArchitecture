using CleanArchitect.Domain.Users;
using CleanArchitect.Infrastructure.Persistence.Users;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitect.Infrastructure.Persistence;


public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}