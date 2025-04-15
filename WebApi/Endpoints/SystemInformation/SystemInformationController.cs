using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Endpoints.SystemInformation.GetPodInformation;

namespace WebApi.Endpoints.SystemInformation;

[ApiController]
[Route("api/system-information")]
public class SystemInformationController(IMediator mediator) : ControllerBase
{
    [HttpGet("pod")]
    [EndpointName(nameof(GetPodInformation))]
    [EndpointSummary("Get Pod information.")]
    [EndpointDescription("This endpoint retrieves the information of the Kubernetes Pod in which the application is currently running.")]
    public ValueTask<Ok<GetPodInformationResponse>> GetPodInformation() => mediator.Send(new GetPodInformationRequest());
}