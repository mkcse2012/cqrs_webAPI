using AutoMapper;
using Product.Application.Contracts.Persistence;
using MediatR;

namespace Product.Application.Features.Products.Queries.GetProductByCode
{
	public class GetProductCodeQueryHandler : IRequestHandler<GetProductCodeQuery, IEnumerable<ProductViewModel>>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public GetProductCodeQueryHandler(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<ProductViewModel>> Handle(GetProductCodeQuery request, CancellationToken cancellationToken)
		{
			var _products = await _productRepository.GetProductByCode(request.Code);
			return _mapper.Map<IEnumerable<ProductViewModel>>(_products);
		}
	}
}

