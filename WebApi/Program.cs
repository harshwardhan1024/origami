using WebApi.Extensions;
using WebApi.Options;

var crashOnStartup = Convert.ToBoolean(Environment.GetEnvironmentVariable("CRASH_ON_STARTUP") ?? "false");
if (crashOnStartup)
{
    throw new Exception("Crashing on startup as requested.");
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediator();
builder.Services.AddOpenApiServices();
builder.Services.AddHealthCheckServices();

builder.Services.Configure<HealthCheckOptions>(builder.Configuration.GetSection(nameof(HealthCheckOptions)));

var app = builder.Build();

app.MapControllers();
app.MapOpenApiRoutes();
app.MapHealthCheckRoutes();

app.Run();