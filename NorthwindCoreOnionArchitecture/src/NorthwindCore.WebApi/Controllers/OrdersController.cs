using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using NorthwindCore.Application.Helpers;

using NorthwindCore.Application.Features.Queries.Orders.GetAllOrders;
using NorthwindCore.Application.Features.Queries.Orders.GetTopOrders;
using NorthwindCore.Application.Features.Queries.Orders.GetOrderById;

using NorthwindCore.Application.Features.Commands.Orders.CreateOrder;
using NorthwindCore.Application.Features.Commands.Orders.DeleteOrder;
using NorthwindCore.WebApi.Action_Filters;

namespace NorthwindCore.API.Controllers
{
    [RBAC] //Authorization
    [Route("api/[controller]/[action]")] //OK
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get ALL Orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrders() //OK
        {
            var query = new GetAllOrdersQuery();
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get Order Count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{count}")] //api/orders/GetOrderById/2
        public async Task<IActionResult> GetTopOrders(int count) //OK
        {
            var query = new GetTopOrdersQuery() { count = count };
            return Ok(await mediator.Send(query));//200 + data    
        }

        /// <summary>
        /// Get Order By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")] //api/orders/GetOrderById/2
        public async Task<IActionResult> GetOrderById(int id) //OK
        {
            var query = new GetOrderByIdQuery() { Id = id };
            var order = await mediator.Send(query); // GetAwaiter().GetResult();

            if (order != null)
            {
                return Ok(order); //200 + data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Create an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest command) //OK
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

                var order = await mediator.Send(command); // GetAwaiter().GetResult();
                return CreatedAtAction("GetOrderById", new { id = order.OrderId }, order);//201 + data                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Delete the order
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrder(int id) //NO CHECK
        {
            var command = new DeleteOrderRequest() { Id = id };
            var order = await mediator.Send(command); // GetAwaiter().GetResult();

            if (order.OrderId == -1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
