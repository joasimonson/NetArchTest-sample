using NetArchTestSample.Entities;

namespace NetArchTestSample.Services;

public interface IProductService : IAsyncDisposable
{
    Task CreateAsync(Product product);
    Task<IEnumerable<Product>> GetProductsAsync();
}
