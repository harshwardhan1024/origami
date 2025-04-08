using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Endpoints.SystemInformation.GetPodInformation;

public class GetPodInformationRequestHandler : IRequestHandler<GetPodInformationRequest, Ok<GetPodInformationResponse>>
{
    public ValueTask<Ok<GetPodInformationResponse>> Handle(GetPodInformationRequest request, CancellationToken cancellationToken)
    {
        return new ValueTask<Ok<GetPodInformationResponse>>(TypedResults.Ok(new GetPodInformationResponse(Environment.GetEnvironmentVariable("POD_NAME"))));
    }
}