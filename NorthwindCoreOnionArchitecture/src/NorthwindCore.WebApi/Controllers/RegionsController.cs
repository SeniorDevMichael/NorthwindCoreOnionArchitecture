using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using NorthwindCore.Application.Helpers;

using NorthwindCore.Application.Features.Queries.Regions.GetAllRegions;
using NorthwindCore.Application.Features.Queries.Regions.GetTopRegions;
using NorthwindCore.Application.Features.Queries.Regions.GetRegionById;

using NorthwindCore.Application.Features.Commands.Regions.CreateRegion;
using NorthwindCore.Application.Features.Commands.Regions.DeleteRegion;
using NorthwindCore.WebApi.Action_Filters;

namespace NorthwindCore.API.Controllers
{
    [RBAC] //Authorization
    [Route("api/[controller]/[action]")] //OK
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public RegionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get ALL Regions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRegions() //OK
        {
            var query = new GetAllRegionsQuery();
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get Region Count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{count}")] //api/regions/GetTopRegions/2
        public async Task<IActionResult> GetTopRegions(int count) //OK
        {
            var query = new GetTopRegionsQuery() { count = count };
            return Ok(await mediator.Send(query));//200 + data     
        }

        /// <summary>
        /// Get Region By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")] //api/regions/GetRegionById/2
        public async Task<IActionResult> GetRegionById(int id) //OK
        {
            var query = new GetRegionByIdQuery() { Id = id };
            var region = await mediator.Send(query); // GetAwaiter().GetResult();

            if (region != null)
            {
                return Ok(region); //200 + data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Create an order
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] CreateRegionRequest command) //OK
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

                    ModelState.AddModelError("errors", messages);
                    return BadRequest(ModelState);//400 + validation errors
                }

                var region = await mediator.Send(command); // GetAwaiter().GetResult();
                return CreatedAtAction("GetRegionById", new { id = region.RegionId }, region);//201 + data                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Delete the region
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRegion(int id) //OK
        {
            var command = new DeleteRegionRequest() { Id = id };
            var region = await mediator.Send(command); // GetAwaiter().GetResult();

            if (region.RegionId == -1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
