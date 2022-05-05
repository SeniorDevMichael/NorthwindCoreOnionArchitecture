using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

using NorthwindCore.Application.Helpers;

using MediatR;

using NorthwindCore.Application.Features.Queries.Customers.GetAllCustomers;
using NorthwindCore.Application.Features.Queries.Customers.GetTopCustomers;
using NorthwindCore.Application.Features.Queries.Customers.GetCustomerById;

using NorthwindCore.Application.Features.Commands.Customers.CreateCustomer;
using NorthwindCore.Application.Features.Commands.Customers.DeleteCustomer;
using NorthwindCore.WebApi.Action_Filters;

namespace NorthwindCore.API.Controllers
{
    [RBAC] //Authorization
    [Route("api/[controller]/[action]")] //OK
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get ALL Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers() //OK
        {
            var query = new GetAllCustomersQuery();
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get Customer Count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{count}")] //api/customers/GetTopCustomers/2
        public async Task<IActionResult> GetTopCustomers(int count) //OK
        {
            var query = new GetTopCustomersQuery() { count = count };
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get Customer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        [HttpGet]
        [Route("{id}")] //api/customers/GetCustomerById/2
        public async Task<IActionResult> GetCustomerById(int id) //OK
        {
            var query = new GetCustomerByIdQuery() { Id = id };
            var customer = await mediator.Send(query); // GetAwaiter().GetResult();

            if (customer != null)
            {
                return Ok(customer); //200 + data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest command) //OK
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

                var customer = await mediator.Send(command); // GetAwaiter().GetResult();
                return CreatedAtAction("GetCustomerById", new { id = customer.CustomerId }, customer);//201 + data
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Delete the customer
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerRequest() { Id = id };
            var customer = await mediator.Send(command); // GetAwaiter().GetResult();

            if (customer.CustomerId == -1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}