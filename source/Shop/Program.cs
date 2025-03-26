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

// list products
app.MapGet("/api/product", async (ShopContext db) =>
{
    var products = await db.Products.ToListAsync();
    return Results.Ok(products);
});

// create product
app.MapPost("/api/product", async (ShopContext db, Product product) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/api/product/{product.Id}", product);
});

app.Run();
