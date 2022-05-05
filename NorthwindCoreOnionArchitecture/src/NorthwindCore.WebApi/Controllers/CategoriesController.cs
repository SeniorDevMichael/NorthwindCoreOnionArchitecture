using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using NorthwindCore.Application.Helpers;

using NorthwindCore.Application.Features.Queries.Categories.GetAllCategories;
using NorthwindCore.Application.Features.Queries.Categories.GetTopCategories;
using NorthwindCore.Application.Features.Queries.Categories.GetCategoryById;

using NorthwindCore.Application.Features.Commands.Categories.CreateCategory;
using NorthwindCore.Application.Features.Commands.Categories.DeleteCategory;
using NorthwindCore.WebApi.Action_Filters;

namespace NorthwindCore.WebApi.Controllers
{
    [RBAC] //Authorization
    [Route("api/[controller]/[action]")] //OK
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get ALL Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get Category Count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{count}")] //api/categories/GetCategoryCount/2
        public async Task<IActionResult> GetTopCategories(int count)
        {
            var query = new GetTopCategoriesQuery() { count = count };
            return Ok(await mediator.Send(query));//200 + data            
        }

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        //[Route("GetCategoryById/{id}")] //api/categories/GetCategoryById/2
        //[Route("[action]/{id}")] //api/categories/GetCategoryById/2
        [Route("{id}")] //api/categories/GetCategoryById/2
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery() { Id = id };
            var category = await mediator.Send(query);//GetAwaiter().GetResult();

            if (category != null)
            {
                return Ok(category); //200 + data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Create category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest command)
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

                var category = await mediator.Send(command);//GetAwaiter().GetResult()
                return CreatedAtAction("GetCategoryById", new { id = category.CategoryId }, category);//201 + data            
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Delete the category
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(int id) //OK
        {
            var command = new DeleteCategoryRequest() { Id = id };
            var category = await mediator.Send(command); // GetAwaiter().GetResult();

            if (category.CategoryId==-1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}