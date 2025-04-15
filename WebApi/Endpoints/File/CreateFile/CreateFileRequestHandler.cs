using System.Text;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using FileOptions = WebApi.Options.FileOptions;

namespace WebApi.Endpoints.File.CreateFile;

public class CreateFileRequestHandler(IOptionsSnapshot<FileOptions> fileOptionsSnapshot, ILogger<CreateFileRequest> logger) : IRequestHandler<CreateFileRequest, Results<Ok, InternalServerError<string>>>
{
    private readonly FileOptions fileOptions = fileOptionsSnapshot.Value;
    
    public async ValueTask<Results<Ok, InternalServerError<string>>> Handle(CreateFileRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var filePath = GetFilePath(request);

            await using var fs = System.IO.File.Create(filePath);
            await Write(request, fs, cancellationToken);
            fs.Close();

            return TypedResults.Ok();
        }
        catch (IOException ex)
        {
            logger.LogError(ex, "Caught exception while creating file");
            return TypedResults.InternalServerError("Could not create file.");
        }
    }
    
    private string GetFilePath(CreateFileRequest request) => 
        string.IsNullOrWhiteSpace(request.Path)
            ? Path.Combine(fileOptions.GetDefaultDirectoryPath(), request.Filename)
            : UseSpecifiedDirectory(request);

    private string UseSpecifiedDirectory(CreateFileRequest request)
    {
        if (!Directory.Exists(request.Path))
        {
            Directory.CreateDirectory(request.Path!);
            using var sw = System.IO.File.AppendText(fileOptions.GetDirectoryListFilePath());
            sw.WriteLine(request.Path);
        }
        
        return Path.Combine(request.Path!, request.Filename);
    }

    private async Task Write(CreateFileRequest request, FileStream fs, CancellationToken cancellationToken)
    {
        if (request.FileSizeInMb is not null)
        {
            fs.SetLength(request.FileSizeInMb.Value * 1024 * 1024);
        }
        else if (!string.IsNullOrWhiteSpace(request.Content))
        {
            var bytes = Encoding.UTF8.GetBytes(request.Content);
            await fs.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
        }
    }
}