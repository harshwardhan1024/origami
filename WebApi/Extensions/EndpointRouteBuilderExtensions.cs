using Scalar.AspNetCore;

namespace WebApi.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void MapOpenApiRoutes(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapOpenApi().CacheOutput();
        endpoints.MapScalarApiReference("/openapi");
    }

    public static void MapHealthCheckRoutes(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/healthz/ready", new()
        {
            Predicate = (check) => check.Tags.Contains("readiness"),
        });
        
        endpoints.MapHealthChecks("/healthz/live", new()
        {
            Predicate = (check) => check.Tags.Contains("liveness"),
        });
    }
}