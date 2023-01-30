using MediatR;

namespace Product.Application.Features.Products.Queries.GetProductList;

public class GetProductLists : IRequest<IEnumerable<ProductViewModel>>
{
	public GetProductLists()
	{
	}
}

