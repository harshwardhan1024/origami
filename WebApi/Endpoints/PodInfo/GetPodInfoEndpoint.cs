using FastEndpoints;

namespace WebApi.Endpoints.PodInfo;

public record PodInfoResponse(string? PodName);

public class GetPodInfoEndpoint : EndpointWithoutRequest<PodInfoResponse>
{
    public override void Configure()
    {
        Get("/pod-info");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        return SendAsync(
            new PodInfoResponse(Environment.GetEnvironmentVariable("POD_NAME")), 
            cancellation: ct);
    }
}