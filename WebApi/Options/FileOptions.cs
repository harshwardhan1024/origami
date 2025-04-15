using System.ComponentModel.DataAnnotations;

namespace WebApi.Options;

public class FileOptions
{
    [Required]
    public string DefaultDirectoryName { get; set; } = null!;

    [Required]
    public string DirectoryListFileName { get; set; } = null!;

    public string GetDefaultDirectoryPath() => Path.Combine(Directory.GetCurrentDirectory(), DefaultDirectoryName);
    
    public string GetDirectoryListFilePath() => Path.Combine(GetDefaultDirectoryPath(), DirectoryListFileName);
}