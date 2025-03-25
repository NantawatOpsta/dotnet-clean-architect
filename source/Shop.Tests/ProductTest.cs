using Microsoft.EntityFrameworkCore;
using Shop.Entity;
using Shop.Usecase;

namespace Shop.Product.Tests;

public class ProductTest
{
    [Fact]
    public void TestGetAvailableProducts()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ShopContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new ShopContext(options))
        {
            context.Products.Add(new Entity.Product { Name = "Product 1", Price = 10, IsAvailable = true });
            context.Products.Add(new Entity.Product { Name = "Product 2", Price = 20, IsAvailable = false });
            context.Products.Add(new Entity.Product { Name = "Product 3", Price = 30, IsAvailable = true });
            context.SaveChanges();

            // Act
            var productUsecase = new Usecase.ProductUsecase(context);
            var availableProducts = productUsecase.GetAvailableProducts();

            // Assert
            Assert.Equal(2, availableProducts.Count());
        }
    }
}
