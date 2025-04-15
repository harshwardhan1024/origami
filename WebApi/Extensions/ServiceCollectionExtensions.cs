using WebApi.Services.Background;
using WebApi.Services.HealthChecks;

namespace WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddOpenApiServices(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((d, ctx, ct) =>
            {
                d.Info = new()
                {
                    Title = "Origami API",
                    Description = @"
The API serves as a flexible environment for testing new tools, exploring technologies, and experimenting with ideas. 
The API evolves continuously as new needs arise."
                };
        
                return Task.CompletedTask;
            });
        });
    }

    public static void AddHealthCheckServices(this IServiceCollection services)
    {
        services.AddSingleton<ReadinessHealthCheck>();
        services.AddHostedService<ReadinessBackgroundService>();
        services.AddHealthChecks()
            .AddCheck<ReadinessHealthCheck>("Readiness Health Check", tags: ["readiness"])
            .AddCheck<ConfigurationHealthCheck>("Configuration Health Check", tags: ["liveness"]);
    }
}