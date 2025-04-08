using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Endpoints.SystemInformation.GetPodInformation;

public record GetPodInformationRequest : IRequest<Ok<GetPodInformationResponse>>;