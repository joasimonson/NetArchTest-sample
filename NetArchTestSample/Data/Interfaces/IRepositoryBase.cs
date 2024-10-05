namespace NetArchTestSample.Data.Interfaces;

public interface IRepositoryBase<T> : IAsyncDisposable where T : class
{
    Task<T> CreateAsync(T entity);
}