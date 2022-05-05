using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using NorthwindCore.Application.Helpers;

using NorthwindCore.Application.Features.Queries.Shippers.GetAllShippers;
using NorthwindCore.Application.Features.Queries.Shippers.GetTopShippers;
using NorthwindCore.Application.Features.Queries.Shippers.GetShipperById;

using NorthwindCore.Application.Features.Commands.Shippers.CreateShipper;
using NorthwindCore.Application.Features.Commands.Shippers.DeleteShipper;
using NorthwindCore.WebApi.Action_Filters;

namespace NorthwindCore.API.Controllers
{
    [RBAC] //Authorization
    [Route("api/[controller]/[action]")] //OK
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShippersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get ALL Shippers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllShippers() //OK
        {
            var query = new GetAllShippersQuery();
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get Shipper Count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{count}")] //api/shippers/GetTopShippers/2
        public async Task<IActionResult> GetTopShippers(int count) //OK
        {
            var query = new GetTopShippersQuery() { count = count };
            return Ok(await mediator.Send(query));//200 + data    
        }

        /// <summary>
        /// Get Shipper By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")] //api/shippers/GetShipperById/2
        public async Task<IActionResult> GetShipperById(int id) //OK
        {
            var query = new GetShipperByIdQuery() { Id = id };
            var shipper = await mediator.Send(query); // GetAwaiter().GetResult();

            if (shipper != null)
            {
                return Ok(shipper); //200 + data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Create shipper
        /// </summary>
        /// <param name="shipper"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateShipper([FromBody] CreateShipperRequest command) //OK
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

                var shipper = await mediator.Send(command); // GetAwaiter().GetResult();
                return CreatedAtAction("GetShipperById", new { id = shipper.ShipperId }, shipper);//201 + data                
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
        public async Task<IActionResult> DeleteShipper(int id) //OK
        {
            var command = new DeleteShipperRequest() { Id = id };
            var shipper = await mediator.Send(command); // GetAwaiter().GetResult();

            if (shipper.ShipperId == -1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}