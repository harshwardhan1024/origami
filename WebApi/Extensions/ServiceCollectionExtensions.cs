namespace WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenApiServices(this IServiceCollection services)
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

        return services;
    }
}