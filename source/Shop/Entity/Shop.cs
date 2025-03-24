using System;
using Microsoft.EntityFrameworkCore;

namespace Shop.Entity;

public class ShopContext : DbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Promotion> Promotions { get; set; }

    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
    }

    // get available products
    public List<Product> GetAvailableProducts()
    {
        return Products.Where(p => p.IsAvailable).ToList();
    }
}

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<Product> Products { get; } = [];
}

public class Promotion
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Discount { get; set; }
    public List<Category> Categories { get; } = [];
}