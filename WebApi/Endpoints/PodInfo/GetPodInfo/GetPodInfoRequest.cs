using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints.PodInfo.GetPodInfo;

public record GetPodInfoRequest : IRequest<IActionResult>;