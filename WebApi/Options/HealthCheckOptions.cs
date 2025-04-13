namespace WebApi.Options;

public class HealthCheckOptions
{
    public bool FailHealthCheck { get; set; }

    public int ReadinessWaitTimeInSeconds { get; set; }
}