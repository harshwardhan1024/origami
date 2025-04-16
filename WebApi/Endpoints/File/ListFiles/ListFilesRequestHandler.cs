using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using FileOptions = WebApi.Options.FileOptions;

namespace WebApi.Endpoints.File.ListFiles;

public class ListFilesRequestHandler(IOptionsSnapshot<FileOptions> fileOptionsSnapshot) : IRequestHandler<ListFilesRequest, Ok<ListFilesResponse>>
{
    private readonly FileOptions fileOptions = fileOptionsSnapshot.Value;
    
    public ValueTask<Ok<ListFilesResponse>> Handle(ListFilesRequest request, CancellationToken cancellationToken)
    {
        var path = string.IsNullOrWhiteSpace(request.Path) ? fileOptions.GetDefaultDirectoryPath() : request.Path;
        var files = Directory.GetFiles(path);
        return new ValueTask<Ok<ListFilesResponse>>(TypedResults.Ok(new ListFilesResponse(files)));
    }
}