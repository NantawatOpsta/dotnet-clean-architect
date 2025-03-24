using System;
using Microsoft.EntityFrameworkCore;

namespace MyShop.Entity;

public class ShopContext : DbContext
{

}

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

public class Promotion
{
    public int Id { get; set; }
    public required string Name { get; set; }
}