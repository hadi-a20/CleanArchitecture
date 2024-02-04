using CleanArchitect.Application;
using CleanArchitect.Infrastructure.Core;
using CleanArchitect.Infrastructure.Persistence;
using CleanArchitect.Presentation.Api;
using CleanArchitect.Presentation.Mappers;

try
{
    var builder = WebApplication.CreateBuilder(args);
    {
        builder.Services
            .AddApi()
            .AddCore(builder.Configuration)
            .AddApplication()
            .AddPersistence()
            .AddMappings(builder.Configuration);
    };

    var app = builder.Build();
    {
        app.UseExceptionHandler("/error");
        app.UseHttpsRedirection();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
catch (Exception ex)
{
    return 1;
}
finally
{
}
return 0;