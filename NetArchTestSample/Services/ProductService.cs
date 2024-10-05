using NetArchTestSample.Data.Interfaces;
using NetArchTestSample.Entities;

namespace NetArchTestSample.Services;

public sealed class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task CreateAsync(Product product) => await productRepository.CreateAsync(product);

    public async Task<IEnumerable<Product>> GetProductsAsync() => await productRepository.GetAllAsync();

    public async ValueTask DisposeAsync() => await productRepository.DisposeAsync();
}
