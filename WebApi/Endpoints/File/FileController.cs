using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Endpoints.File.CreateFile;
using WebApi.Endpoints.File.ListFiles;

namespace WebApi.Endpoints.File;

[ApiController]
[Route("api/file")]
public class FileController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [EndpointName(nameof(CreateFile))]
    [EndpointSummary("Create a file")]
    [EndpointDescription("""
                         This endpoint creates a file with the specified filename.
                         Only filename is required, rest fields are optional.
                         If path is not provided, the file will be created in a default directory.
                         If provided, then content will be written to the file. 
                         However, if fileSizeInMb is provided, then content will be ignored and an empty file will be created with the specified size.
                         """)]
    public ValueTask<Results<Ok, InternalServerError<string>>> CreateFile([FromBody] CreateFileRequest req) => mediator.Send(req);
    
    [HttpGet]
    [EndpointName(nameof(ListFiles))]
    [EndpointSummary("List files")]
    [EndpointDescription("This endpoint lists all files in the specified directory. If no directory is specified, it will list files in the default directory.")]
    public ValueTask<Ok<ListFilesResponse>> ListFiles([FromQuery] ListFilesRequest req) => mediator.Send(req);

}