# .NET

```
# initial project
docker compose up --build

# migrate database
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef database update 0

# sonarqube scan
dotnet sonarscanner begin /k:"your_project_key" /o:"your_organization" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="your_sonar_token"

dotnet build

dotnet sonarscanner end /d:sonar.login="your_sonar_token"

```

https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-9.0&tabs=visual-studio
https://learn.microsoft.com/en-us/ef/core/