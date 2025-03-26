# .NET

```
# initial project
docker compose up --build

# migrate database
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```