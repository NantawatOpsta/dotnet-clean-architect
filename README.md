# .NET

```
# initial project
docker compose up --build

# migrate database
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-9.0&tabs=visual-studio
https://learn.microsoft.com/en-us/ef/core/