using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using WebApi.Options;

namespace WebApi.Services.HealthChecks;

public class ConfigurationHealthCheck(IOptionsSnapshot<HealthCheckOptions> healthCheckOptionsSnapshot) : IHealthCheck
{
    private readonly HealthCheckOptions healthCheckOptions = healthCheckOptionsSnapshot.Value;
    
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        if (healthCheckOptions.FailHealthCheck)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy("Configuration health check failed."));
        }

        return Task.FromResult(HealthCheckResult.Healthy("Configuration health check passed."));
    }
}