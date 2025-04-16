using WebApi.Extensions;
using WebApi.Middlewares;
using WebApi.Options;
using WebApi.Services.Background;
using FileOptions = WebApi.Options.FileOptions;

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
builder.Services.AddHostedService<CreateDirectoryBackgroundService>();

builder.Services.Configure<HealthCheckOptions>(builder.Configuration.GetSection(nameof(HealthCheckOptions)));
builder.Services.Configure<SystemInformationOptions>(
    builder.Configuration.GetSection(nameof(SystemInformationOptions)));
builder.Services.AddOptions<FileOptions>()
    .Bind(builder.Configuration.GetSection(nameof(FileOptions)))
    .ValidateDataAnnotations()
    .ValidateOnStart();

var app = builder.Build();

app.UseMiddleware<ResponseHeadersEnricherMiddleware>();
app.MapControllers();
app.MapOpenApiRoutes();
app.MapHealthCheckRoutes();

app.Run();