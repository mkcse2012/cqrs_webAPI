using MediatR;
using Product.Application.Contracts.Persistence;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Product.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
	private readonly IProductRepository _productRepository;
	private readonly IMapper _mapper;
	private readonly ILogger<CreateProductCommandHandler> _logger;

	public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
	{
		_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		var _productEntity = _mapper.Map<Product.Domain.Entities.Product>(request);
		var _newProduct = await _productRepository.AddAsync(_productEntity);

		_logger.LogInformation($"Product - {_newProduct.Code} and {_newProduct.Name} has been created successfully...!");
		return _newProduct.Id;
	}
}

