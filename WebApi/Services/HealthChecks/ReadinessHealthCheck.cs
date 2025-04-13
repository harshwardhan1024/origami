using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApi.Services.HealthChecks;

public class ReadinessHealthCheck : IHealthCheck
{
    public bool IsReady { get; set; }
    
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        if (IsReady)
        {
            return Task.FromResult(HealthCheckResult.Healthy("App is ready."));
        }

        return Task.FromResult(HealthCheckResult.Unhealthy("Startup tasks are still running."));
    }
}