using AutoMapper;
using Product.Application.Features.Products.Commands.CreateProduct;
using Product.Application.Features.Products.Queries;

namespace Product.Application.Mappings;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Product.Domain.Entities.Product, ProductViewModel>().ReverseMap();
		CreateMap<Product.Domain.Entities.Product, CreateProductCommand>().ReverseMap();
	}
}

