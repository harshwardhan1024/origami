using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using WebApi.Options;

namespace WebApi.Endpoints.SystemInformation.GetPodInformation;

public class GetPodInformationRequestHandler(IOptionsSnapshot<SystemInformationOptions> systemInformationOptionsSnapshot) : IRequestHandler<GetPodInformationRequest, Ok<GetPodInformationResponse>>
{
    private readonly SystemInformationOptions systemInformationOptions = systemInformationOptionsSnapshot.Value;
    
    public ValueTask<Ok<GetPodInformationResponse>> Handle(GetPodInformationRequest request, CancellationToken cancellationToken)
    {
        return new ValueTask<Ok<GetPodInformationResponse>>(TypedResults.Ok(new GetPodInformationResponse(systemInformationOptions.PodName)));
    }
}