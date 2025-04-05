using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints.PodInfo.GetPodInfo;

public class GetPodInfoRequestHandler : IRequestHandler<GetPodInfoRequest, IActionResult>
{
    public ValueTask<IActionResult> Handle(GetPodInfoRequest request, CancellationToken cancellationToken)
    {
        return new ValueTask<IActionResult>(new OkObjectResult(new GetPodInfoResponse(Environment.GetEnvironmentVariable("POD_NAME"))));
    }
}