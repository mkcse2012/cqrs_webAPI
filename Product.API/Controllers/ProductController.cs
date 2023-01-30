using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Features.Products.Commands.CreateProduct;
using Product.Application.Features.Products.Queries.GetProductByCode;
using Product.Application.Features.Products.Queries.GetProductList;
using Product.Application.Features.Products.Queries;
using MediatR;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<ActionResult> GetAllProductAsync()
    {
        var results = await _mediator.Send(new GetProductLists());
        return Ok(results);
    }

    [HttpGet("{Code}", Name = "GetProductByCode")]
    [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductByCode(string Code)
    {
        var query = new GetProductCodeQuery(Code);
        var results = await _mediator.Send(query);
        return Ok(results);
    }

    [HttpPost(Name = "CreateProduct")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

