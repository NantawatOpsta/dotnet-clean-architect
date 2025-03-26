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

    public List<Product> GetAvailableProducts()
    {
        return _context.Products
            .Where(p => p.IsAvailable)
            .ToList();
    }
    
}


