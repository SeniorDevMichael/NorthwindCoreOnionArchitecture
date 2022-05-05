using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using NorthwindCore.Application.Helpers;

using NorthwindCore.Application.Features.Queries.OrderDetails.GetAllOrderDetails;
using NorthwindCore.Application.Features.Queries.OrderDetails.GetTopOrderDetails;
using NorthwindCore.Application.Features.Queries.OrderDetails.GetOrderDetailById;
using NorthwindCore.Application.Features.Commands.OrderDetails.CreateOrderDetail;
using NorthwindCore.Application.Features.Commands.OrderDetails.DeleteOrderDetail;
using NorthwindCore.WebApi.Action_Filters;

//using NorthwindCore.Application.Features.Commands.OrderDetails.CreateOrder;
//using NorthwindCore.Application.Features.Commands.OrderDetails.DeleteOrder;

namespace NorthwindCore.API.Controllers
{
    [RBAC] //Authorization
    [Route("api/[controller]/[action]")] //OK
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderDetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get ALL OrderDetails
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetails() //NOT OK
        {
            var query = new GetAllOrderDetailsQuery();
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get OrderDetail Count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{count}")] //api/orderdetails/GetTopOrderDetails/2
        public async Task<IActionResult> GetTopOrderDetails(int count) //OK
        {
            var query = new GetTopOrderDetailsQuery() { count = count };
            return Ok(await mediator.Send(query));//200 + data    
        }

        /// <summary>
        /// Get OrderDetail By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")] //api/orderdetails/GetOrderDetailById/2
        public async Task<IActionResult> GetOrderDetailById(int id) //OK
        {
            var query = new GetOrderDetailByIdQuery() { Id = id };
            var order_detail = await mediator.Send(query); // GetAwaiter().GetResult();

            if (order_detail.Count()>0)
            {
                return Ok(order_detail); //200 + data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Create an order
        /// </summary>
        /// <param name="order_details"></param>
        /// <returns></returns>        
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailRequest command) //NOT OK
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

                var order_detail = await mediator.Send(command); // GetAwaiter().GetResult();
                return CreatedAtAction("GetOrderDetailById", new { id = order_detail.OrderId }, order_detail);//201 + data
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        /// <summary>
        /// Delete the order-detail
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrderDetails(int id)
        {
            var command = new DeleteOrderDetailRequest() { OrderId = id };
            var order = await mediator.Send(command); // GetAwaiter().GetResult();

            if (order.OrderId == -1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}