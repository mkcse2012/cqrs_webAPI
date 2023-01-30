using MediatR;

namespace Product.Application.Features.Products.Queries.GetProductByCode;

public class GetProductCodeQuery : IRequest<IEnumerable<ProductViewModel>>
{
	public string Code { get; set; }

	public GetProductCodeQuery(string productCode)
	{
		Code = productCode ?? throw new ArgumentNullException(nameof(Code));
	}
}

