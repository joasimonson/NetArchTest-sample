using NetArchTestSample.Entities;
using NetArchTestSample.Services;

namespace NetArchTestSample.Presentation;

public class ProductController(IProductService productService)
{
    public async Task CreateProduct(int id, string name, decimal price)
        => await productService.CreateAsync(new()
        {
            Id = id,
            Name = name,
            Price = price
        });

    public async Task<IEnumerable<Product>> GetProductsAsync() => await productService.GetProductsAsync();
}
