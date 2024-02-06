using CleanArchitect.Application;
using CleanArchitect.Infrastructure.Core;
using CleanArchitect.Infrastructure.Persistence;
using CleanArchitect.Presentation.Api;
using CleanArchitect.Presentation.Mappers;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

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

    builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext());

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
    app.UseSerilogRequestLogging(configure =>
    {
        configure.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms";
    });
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectadly!!");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
return 0;