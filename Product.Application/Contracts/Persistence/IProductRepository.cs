
namespace Product.Application.Contracts.Persistence;

public interface IProductRepository : IAsyncRepository<Product.Domain.Entities.Product>
{
    Task<IEnumerable<Product.Domain.Entities.Product>> GetProductByCode(string Code);
}

