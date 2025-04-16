using Microsoft.Extensions.Options;
using WebApi.Options;

namespace WebApi.Middlewares;

public class ResponseHeadersEnricherMiddleware(
    RequestDelegate next, 
    IOptionsSnapshot<SystemInformationOptions> systemInformationOptionsSnapshot)
{
    private readonly SystemInformationOptions systemInformationOptions = systemInformationOptionsSnapshot.Value;
    
    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Append("PodName", systemInformationOptions.PodName);
        await next(context);
    }
}