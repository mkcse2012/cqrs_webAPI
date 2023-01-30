using MediatR;

namespace Product.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Guid>
{
	public Guid Id { get; set; }
	public string? Code { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
}

