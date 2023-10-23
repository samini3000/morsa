using Application.Account;
using Application.Product;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet("Products")]   
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new GetAllProductCommand(), cancellationToken);
            if(products == null)
            {
                return BadRequest("there isn't any");
            }
            return Ok(products);   
        }
        [Authorize]
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product, CancellationToken cancellationToken)
        {
            var account = await _mediator.Send(new GetByIdCommand(product.AccountRef), cancellationToken);
            if (account.CanInsert)
            {
                await _mediator.Send(new AddProductCommand(product), cancellationToken);
                account.CanInsert = false;
                await _mediator.Send(new UpdateAccountCommand(account), cancellationToken);
            }
            else
            {
                return Ok("this account added its produt ealier");
            }
            return Ok();
        }
    }
}