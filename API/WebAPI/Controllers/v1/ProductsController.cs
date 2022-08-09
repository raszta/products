using Application.Commands;
using Application.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var productToReturn = await _mediator.Send(new CreateProductCommand(product));
            return Ok(productToReturn);
        }
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }
        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery { Id = id }));
        }
        
    }
}
