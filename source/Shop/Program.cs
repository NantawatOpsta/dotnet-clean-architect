using Shop.Usecase;
using Microsoft.EntityFrameworkCore;
using Shop.Entity;
using Microsoft.Extensions.Logging;

using ILoggerFactory factory = LoggerFactory.Create(builder => builder
    .AddConsole()
    .SetMinimumLevel(LogLevel.Debug));
ILogger logger = factory.CreateLogger("Shop");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]);
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
    logger.LogInformation("list products");
    var products = await db.Products.ToListAsync();
    return Results.Ok(products);
});

// create product
app.MapPost("/api/product", async (ShopContext db, Product product) =>
{
    logger.LogInformation("create product");
    logger.LogDebug("Product Details - Id: {Id}, Name: {Name}, Price: {Price}", 
        product.Id, 
        product.Name, 
        product.Price);
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/api/product/{product.Id}", product);
});

// delete product
app.MapDelete("/api/product/{id}", async (ShopContext db, int id) =>
{
    var product = await db.Products.FindAsync(id);
    if (product == null)
    {
        return Results.NotFound();
    }
    db.Products.Remove(product);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
