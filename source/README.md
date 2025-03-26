# .NET

```
# initial project
docker compose up --build

# migrate database
docker exec -it app dotnet tool install --global dotnet-ef
docker exec -it app dotnet ef migrations add InitialCreate
docker exec -it app dotnet ef database update
```