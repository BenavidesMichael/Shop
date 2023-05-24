using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using System.Net;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        //private readonly IMediator _mediator;

        //public ProductControler(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        [HttpGet(nameof(GetProducts))]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            //var query = new GetProductsRequest();
            //var products = await _mediator.Send(query);
            //return Ok(products);
            return Ok("products");
        }
    }
}
