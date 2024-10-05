using NetArchTestSample.Entities;

namespace NetArchTestSample.Data.Interfaces;

public interface IProductRepository : IRepositoryBase<Product>
{
    Task<IEnumerable<Product>> GetAllAsync();
}
