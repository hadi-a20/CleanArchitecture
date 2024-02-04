using CleanArchitect.Presentation.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArchitect.Presentation.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();

        return services;
    }
}