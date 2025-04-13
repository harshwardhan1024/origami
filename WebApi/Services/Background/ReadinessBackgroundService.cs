using Microsoft.Extensions.Options;
using WebApi.Options;
using WebApi.Services.HealthChecks;

namespace WebApi.Services.Background;

public class ReadinessBackgroundService(IOptionsSnapshot<HealthCheckOptions> healthCheckOptionsSnapshot, ReadinessHealthCheck readinessHealthCheck) : BackgroundService
{
    private readonly HealthCheckOptions healthCheckOptions = healthCheckOptionsSnapshot.Value;
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (healthCheckOptions.ReadinessWaitTimeInSeconds > 0)
        {
            await Task.Delay(TimeSpan.FromSeconds(healthCheckOptions.ReadinessWaitTimeInSeconds), stoppingToken);
        }
        
        readinessHealthCheck.IsReady = true;
    }
}