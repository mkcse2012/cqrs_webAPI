using Product.Application.Contracts.Persistence;
using Product.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Product.Infrastructure.Repositories;

public class ProductRepository : RepositoryBase<Product.Domain.Entities.Product>, IProductRepository
{
	public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}

	public async Task<IEnumerable<Product.Domain.Entities.Product>> GetProductByCode(string productCode)
	{
		return await _dbContext.Products.Where(x => x.Code == productCode).ToListAsync();
	}
}

