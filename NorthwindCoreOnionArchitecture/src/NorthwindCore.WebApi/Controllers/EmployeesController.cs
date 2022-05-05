using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using NorthwindCore.Application.Helpers;

using NorthwindCore.Application.Features.Queries.Employees.GetAllEmployees;
using NorthwindCore.Application.Features.Queries.Employees.GetTopEmployees;
using NorthwindCore.Application.Features.Queries.Employees.GetEmployeeById;

using NorthwindCore.Application.Features.Commands.Employees.CreateEmployee;
using NorthwindCore.Application.Features.Commands.Employees.DeleteEmployee;
using NorthwindCore.WebApi.Action_Filters;

namespace NorthwindCore.API.Controllers
{
    [RBAC] //Authorization
    [Route("api/[controller]/[action]")] //OK
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get ALL Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees() //OK
        {
            var query = new GetAllEmployeesQuery();
            return Ok(await mediator.Send(query));//200 + data
        }

        /// <summary>
        /// Get Category Count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{count}")] //api/employees/GetTopEmployees/2
        public async Task<IActionResult> GetTopEmployees(int count) //OK
        {
            var query = new GetTopEmployeesQuery() { count = count };
            return Ok(await mediator.Send(query));//200 + data     
        }

        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")] //api/employees/GetEmployeeById/2
        public async Task<IActionResult> GetEmployeeById(int id) //OK
        {
            var query = new GetEmployeeByIdQuery() { Id = id };
            var employee = await mediator.Send(query); // GetAwaiter().GetResult();

            if (employee != null)
            {
                return Ok(employee); //200 + data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Create an employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest command) //OK
        {
            try
            {
                if (command == null)
                {
                    //return BadRequest();

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

                var employee = await mediator.Send(command); // GetAwaiter().GetResult();
                return CreatedAtAction("GetEmployeeById", new { id = employee.EmployeeId }, employee);//201 + data
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Delete the employee
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id) //OK
        {
            var command = new DeleteEmployeeRequest() { Id = id };
            var employee = await mediator.Send(command); // GetAwaiter().GetResult();

            if (employee.EmployeeId == -1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}