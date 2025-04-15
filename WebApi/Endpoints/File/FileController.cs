using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Endpoints.File.CreateFile;

namespace WebApi.Endpoints.File;

[ApiController]
[Route("api/file")]
public class FileController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [EndpointName(nameof(CreateFile))]
    [EndpointSummary("Create a file.")]
    [EndpointDescription("""
                         This endpoint creates a file with the specified filename.
                         Only filename is required, rest fields are optional.
                         If path is not provided, the file will be created in a default directory.
                         If provided, then content will be written to the file. 
                         However, if fileSizeInMb is provided, then content will be ignored and an empty file will be created with the specified size.
                         """)]
    public ValueTask<Results<Ok, InternalServerError<string>>> CreateFile([FromBody] CreateFileRequest req) => mediator.Send(req);

}