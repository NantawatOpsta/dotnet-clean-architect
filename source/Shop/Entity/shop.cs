using System;
using Microsoft.EntityFrameworkCore;

namespace Shop.Entity;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Promotion> Promotions { get; set; }

    // get available products
    public List<Product> GetAvailableProducts()
    {
        return [.. Products.Where(p => p.IsAvailable)];
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
}