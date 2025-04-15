using Microsoft.Extensions.Options;
using FileOptions = WebApi.Options.FileOptions;

namespace WebApi.Services.Background;

public class CreateDirectoryBackgroundService(
    IOptionsSnapshot<FileOptions> fileOptionsSnapshot, 
    ILogger<CreateDirectoryBackgroundService> logger) : BackgroundService
{
    private readonly FileOptions fileOptions = fileOptionsSnapshot.Value;
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var defaultDirectoryPath = fileOptions.GetDefaultDirectoryPath();
        if (!Directory.Exists(defaultDirectoryPath))
        {
            Directory.CreateDirectory(defaultDirectoryPath);
            logger.LogInformation("Created a default directory for files at: {defaultDirectoryPath}", defaultDirectoryPath);
        }

        var directoryList = Path.Combine(defaultDirectoryPath, fileOptions.DirectoryListFileName);
        if (!File.Exists(directoryList))
        {
            using var fs = File.Create(directoryList);
            fs.Close();
            logger.LogInformation($"Created {fileOptions.DirectoryListFileName}");
        }
        
        return Task.CompletedTask;
    }
}