using System;
using Shop.Entity;

namespace Shop.Usecase;


public class ProductUsecase
{
    private readonly ShopContext _context;

    public ProductUsecase(ShopContext context)
    {
        _context = context;
    }

    public Product CreateProduct(string name, decimal price, bool isAvailable)
    {
        var product = new Product
        {
            Name = name,
            Price = price,
            IsAvailable = isAvailable
        };

        _context.Products.Add(product);
        _context.SaveChanges();

        return product;
    }

    public IEnumerable<Product> GetAvailableProducts()
    {
        return _context.Products.Where(p => p.IsAvailable);
    }
}


