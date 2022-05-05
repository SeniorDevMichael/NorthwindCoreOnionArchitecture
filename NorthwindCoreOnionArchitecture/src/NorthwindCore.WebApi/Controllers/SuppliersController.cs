using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using NorthwindCore.Application.Helpers;

using NorthwindCore.Application.Features.Queries.Suppliers.GetAllSuppliers;
using NorthwindCore.Application.Features.Queries.Suppliers.GetTopSuppliers;
using NorthwindCore.Application.Features.Queries.Suppliers.GetSupplierById;

using NorthwindCore.Application.Features.Commands.Suppliers.CreateSupplier;
using NorthwindCore.Application.Features.Commands.Suppliers.DeleteSupplier;

namespace NorthwindCore.API.Controllers
{
    [Route("api/[controller]/[action]")] //OK
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator mediator;

        public SuppliersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get ALL Suppliers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers() //OK
        {
            var query = new GetAllSuppliersQuery();
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get Supplier Count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{count}")] //api/suppliers/GetTopSuppliers/2
        public async Task<IActionResult> GetTopSuppliers(int count) //OK
        {
            var query = new GetTopSuppliersQuery() { count = count };
            return Ok(await mediator.Send(query));//200 + data 
        }

        /// <summary>
        /// Get Supplier By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")] //api/suppliers/GetSupplierById/2
        public async Task<IActionResult> GetSupplierById(int id) //OK
        {
            var query = new GetSupplierByIdQuery() { Id = id };
            var supplier = await mediator.Send(query); // GetAwaiter().GetResult();

            if (supplier != null)
            {
                return Ok(supplier); //200 + data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Create supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierRequest command) //OK
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

                var supplier = await mediator.Send(command); // GetAwaiter().GetResult();
                return CreatedAtAction("GetSupplierById", new { id = supplier.SupplierId }, supplier);//201 + data                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Delete the supplier
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id) //OK
        {
            var command = new DeleteSupplierRequest() { Id = id };
            var supplier = await mediator.Send(command); // GetAwaiter().GetResult();

            if (supplier.SupplierId == -1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
