using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Shop.Application.Features.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Authorization;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductControler(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpGet(nameof(GetProducts))]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IReadOnlyList<GetProductsResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<GetProductsResponse>>> GetProducts()
        {
            var query = new GetProductsRequest();
            var products = await _mediator.Send(query);
            return Ok(products);
        }
    }
}
