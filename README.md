## Environment Variables

| Name                                           | Description                                            | Required | Default |
|------------------------------------------------|--------------------------------------------------------|----------|---------|
| POD_NAME                                       | The name of the pod.                                   |          |         |
| CRASH_ON_STARTUP                               | If set to true, the application will crash on startup. |          |         |
| HealthCheckOptions__FailHealthCheck            | If set to true, the health check will fail.            | false    | false   |
| HealthCheckOptions__ReadinessWaitTimeInSeconds | The time to wait before the readiness check is passed. | false    | 0       |

## Updating .NET version

To update the .NET version, make update in following places:
- `WebApi.csproj`
- `build.yml`
- `Dockerfile`

## OpenAPI generation

For OpenAPI generation, we are using:

```xml
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.3" />
```
and in `Program.cs` we have configured it like this:

```csharp
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi()
    .CacheOutput();
```
We can view the OpenAPI spec at: `/openapi/v1.json`

### Endpoint metadata
For endpoint configuration we are attributes on Controller actions.
```csharp
[HttpGet]
[EndpointSummary("Get Pod information.")]
[EndpointDescription("This endpoint retrieves the information of the current Pod, including its name.")]
[EndpointName(nameof(GetPodInfo))]
public ValueTask<Ok<GetPodInfoResponse>> GetPodInfo() => mediator.Send(new GetPodInfoRequest());
```
### UI
For UI we are using Scalar.
```xml
<PackageReference Include="Scalar.AspNetCore" Version="2.1.7" />
```

and then we have configured it as:
```csharp
app.MapScalarApiReference();
```

Then we can view the UI at: `/scalar/v1`


Maybe README should have everyday or most common tasks info.

And less relevant or less frequently info should go in contribution guide.


- General information, How to run, how to build.
- How to extend? add new endpoint, add metadata
- How we did something? like openapi generation, UI integration
- Whys