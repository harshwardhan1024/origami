using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Endpoints.SystemInformation.GetPodInformation;

namespace WebApi.Endpoints.SystemInformation;

[ApiController]
[Route("system-information")]
public class SystemInformationController(IMediator mediator) : ControllerBase
{
    [HttpGet("pod")]
    [EndpointSummary("Get Pod information.")]
    [EndpointDescription("This endpoint retrieves the information of the Kubernetes Pod in which the application is currently running.")]
    [EndpointName(nameof(GetPodInformation))]
    public ValueTask<Ok<GetPodInformationResponse>> GetPodInformation() => mediator.Send(new GetPodInformationRequest());
}