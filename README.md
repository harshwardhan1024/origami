## Environment Variables

| Name | Description                                            |
|-------------------|--------------------------------------------------------|
| POD_NAME | The name of the pod.                                   |
| CRASH_ON_STARTUP | If set to true, the application will crash on startup. |

## Updating .NET version

To update the .NET version, make update in following places:
- `WebApi.csproj`
- `build.yml`
- `Dockerfile`