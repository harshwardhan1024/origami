using Microsoft.AspNetCore.Mvc;
using Mediator;
using WebApi.Endpoints.PodInfo.GetPodInfo;

namespace WebApi.Endpoints.PodInfo;

[ApiController]
[Route("pod-info")]
public class PodInfoController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetPodInfo() => mediator.Send(new GetPodInfoRequest());
}