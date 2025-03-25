using Shop.Usecase;
using Microsoft.EntityFrameworkCore;
using Shop.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// health check
app.MapGet("/", () => Results.Ok("Healthy"));

// post /products
app.MapPost("/product", async (ShopContext context, Product product) =>
{
    context.Products.Add(product);
    await context.SaveChangesAsync();

    // return created product in json format
    return Results.Created($"/product/{product.Id}", product);
});

// get /product
app.MapGet("/product", async (ShopContext context) =>
{
    var products = await context.Products.ToListAsync();
    return Results.Ok(products);
});

app.Run();
