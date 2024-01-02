## TaskTracker API
```
dotnet user-secrets init --project .\src\TaskTracker.Api
dotnet user-secrets list --project .\src\TaskTracker.Api
dotnet user-secrets set --project .\src\TaskTracker.Api "ConnectionStrings:SqlConnection" "super-secret-value"
```
## TaskTracker Console
```
dotnet user-secrets init --project .\src\TaskTracker.Console
dotnet user-secrets list --project .\src\TaskTracker.Console
dotnet user-secrets set --project .\src\TaskTracker.Console "ConnectionStrings:SqlConnection" "super-secret-value"
```