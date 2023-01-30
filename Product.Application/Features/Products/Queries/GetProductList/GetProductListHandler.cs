using MediatR;
using Product.Application.Contracts.Persistence;
using AutoMapper;

namespace Product.Application.Features.Products.Queries.GetProductList;

public class GetProductListHandler : IRequestHandler<GetProductLists, IEnumerable<ProductViewModel>>
{
	private readonly IProductRepository _productRepository;
	private readonly IMapper _mapper;

	public GetProductListHandler(IProductRepository productRepository, IMapper mapper)
	{
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

	public async Task<IEnumerable<ProductViewModel>> Handle(GetProductLists request, CancellationToken cancellationToken)
	{
		var _productList = await _productRepository.GetAllAsync();
		return _mapper.Map<IEnumerable<ProductViewModel>>(_productList);
	}
}

