using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SayHelloController : ControllerBase
{
    public IActionResult Index(string? name)
    {
        return string.IsNullOrWhiteSpace(name) ? Ok("Hello") : Ok($"Hello, {name}");
    }
}