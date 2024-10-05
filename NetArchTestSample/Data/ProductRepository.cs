using NetArchTestSample.Data.Interfaces;
using NetArchTestSample.Entities;

namespace NetArchTestSample.Data;

public sealed class ProductRepository : IProductRepository
{
    public Task<Product> CreateAsync(Product entity) => throw new NotImplementedException();

    public Task<IEnumerable<Product>> GetAllAsync() => throw new NotImplementedException();

    public ValueTask DisposeAsync() => throw new NotImplementedException();
}
