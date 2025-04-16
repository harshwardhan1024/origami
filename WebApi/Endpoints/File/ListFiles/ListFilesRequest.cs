using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Endpoints.File.ListFiles;

public class ListFilesRequest : IRequest<Ok<ListFilesResponse>>
{
    public string? Path { get; set; }
}