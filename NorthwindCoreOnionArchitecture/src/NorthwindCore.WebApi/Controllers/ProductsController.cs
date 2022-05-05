using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using NorthwindCore.Application.Helpers;

using NorthwindCore.Application.Features.Queries.Products.GetAllProducts;
using NorthwindCore.Application.Features.Queries.Products.GetTopProducts;
using NorthwindCore.Application.Features.Queries.Products.GetProductById;

using NorthwindCore.Application.Features.Commands.Products.CreateProduct;
using NorthwindCore.Application.Features.Commands.Products.DeleteProduct;
using NorthwindCore.WebApi.Action_Filters;

namespace NorthwindCore.API.Controllers
{
    [RBAC] //Authorization
    [Route("api/[controller]/[action]")] //OK
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get ALL Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() //OK
        {
            var query = new GetAllProductsQuery();
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get Product Count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{count}")] //api/products/GetTopProducts/2
        public async Task<IActionResult> GetTopProducts(int count) //OK
        {
            var query = new GetTopProductsQuery() { count = count };
            return Ok(await mediator.Send(query));//200 + data 
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")] //api/products/GetProductById/2
        public async Task<IActionResult> GetProductById(int id) //OK
        {
            var query = new GetProductByIdQuery() { Id = id };
            var product = await mediator.Send(query); // GetAwaiter().GetResult();

            if (product != null)
            {
                return Ok(product); //200 + data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Create an product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest command) //NOT OK
        {
            try
            {
                if (command == null)
                {
                    return BadRequest(new ErrorMessage
                    {
                        Message = "Request object is empty",
                        StatusCode = 400
                    });
                }

                if (!ModelState.IsValid)
                {
                    string messages = string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));

                    ModelState.AddModelError("validation_errors", messages);

                    return BadRequest(ModelState);//400 + validation errors
                }

                var product = await mediator.Send(command); // GetAwaiter().GetResult();
                return CreatedAtAction("GetProductById", new { id = product.ProductId }, product);//201 + data                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database" + ex.ToString());
            }
        }

        /// <summary>
        /// Delete the product
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) //OK
        {
            var command = new DeleteProductRequest() { Id = id };
            var product = await mediator.Send(command); // GetAwaiter().GetResult();

            if (product.ProductId == -1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}