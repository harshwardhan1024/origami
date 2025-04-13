using WebApi.Extensions;
using WebApi.Options;
using WebApi.Services.Background;
using WebApi.Services.HealthChecks;

var crashOnStartup = Convert.ToBoolean(Environment.GetEnvironmentVariable("CRASH_ON_STARTUP") ?? "false");
if (crashOnStartup)
{
    throw new Exception("Crashing on startup as requested.");
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediator();
builder.Services.AddOpenApiServices();
builder.Services.AddSingleton<ReadinessHealthCheck>();
builder.Services.AddHostedService<ReadinessBackgroundService>();
builder.Services.AddHealthChecks()
    .AddCheck<ReadinessHealthCheck>("Readiness Health Check", tags: ["readiness"])
    .AddCheck<ConfigurationHealthCheck>("Configuration Health Check", tags: ["liveness"]);

builder.Services.Configure<HealthCheckOptions>(builder.Configuration.GetSection(nameof(HealthCheckOptions)));

var app = builder.Build();

app.MapControllers();
app.MapOpenApiRoutes();
app.MapHealthChecks("/healthz/ready", new()
{
    Predicate = (check) => check.Tags.Contains("readiness"),
});
app.MapHealthChecks("/healthz/live", new()
{
    Predicate = (check) => check.Tags.Contains("liveness"),
});

app.Run();