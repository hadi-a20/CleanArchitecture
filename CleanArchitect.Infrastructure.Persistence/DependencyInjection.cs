using CleanArchitect.Domain.Users;
using CleanArchitect.Infrastructure.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitect.Infrastructure.Persistence;


public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        var dbConfiguration = configuration.GetSection("RelationalDbConnection");
        services.AddDbContext<CleanDbContext>(options => options.UseSqlServer(dbConfiguration.Value));
        return services;
    }
}