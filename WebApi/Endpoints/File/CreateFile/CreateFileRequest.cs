using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Endpoints.File.CreateFile;

public record CreateFileRequest(string Filename, string? Content, string? Path, int? FileSizeInMb) : IRequest<Results<Ok, InternalServerError<string>>>;