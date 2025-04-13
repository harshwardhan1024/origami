using Scalar.AspNetCore;

namespace WebApi.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void MapOpenApiRoutes(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapOpenApi().CacheOutput();
        endpoints.MapScalarApiReference("/openapi");
    }
}