using Shop.Usecase;
using Microsoft.EntityFrameworkCore;
using Shop.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseNpgsql("Host=db;Database=postgres;Username=postgres;Password=password");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// health check
app.MapGet("/", () => Results.Ok("Healthy"));

app.MapGet("/api/product", async (ShopContext db) =>
{
    var products = await db.Products.ToListAsync();
    return Results.Ok(products);
});

app.Run();
