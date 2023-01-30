using Product.Application.Contracts.Persistence;
using Product.Infrastructure.Persistence;
using Product.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Product.Infrastructure;

public static class InfrastructureServiceRegistration
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Product.API")));

		services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
		services.AddScoped<IProductRepository, ProductRepository>();

		return services;
	}
}

