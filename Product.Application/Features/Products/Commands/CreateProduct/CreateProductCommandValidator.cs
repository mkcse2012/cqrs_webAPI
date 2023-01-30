using FluentValidation;

namespace Product.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Please enter the product code")
            .NotNull();

        RuleFor(p => p.Name)
			.NotEmpty().WithMessage("Please enter the product name")
			.NotNull();
	}
}

