using WebApi.Extensions;

var crashOnStartup = Convert.ToBoolean(Environment.GetEnvironmentVariable("CRASH_ON_STARTUP") ?? "false");
if (crashOnStartup)
{
    throw new Exception("Crashing on startup as requested.");
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediator();
builder.Services.AddOpenApiServices();

var app = builder.Build();

app.MapControllers();
app.MapOpenApiRoutes();

app.Run();