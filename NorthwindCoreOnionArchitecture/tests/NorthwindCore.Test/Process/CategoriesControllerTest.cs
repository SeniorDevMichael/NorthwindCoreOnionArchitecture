using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthwindCore.WebApi.Controllers;
using Xunit;

namespace NorthwindCore.Test.Process
{
    public class CategoriesControllerTest
    {
        private readonly IMediator mediator;
        private readonly CategoriesController _controller;

        public CategoriesControllerTest(IMediator mediator)
        {
            this.mediator = mediator;
            _controller = new CategoriesController(mediator);
        }

        [Fact]
        public async Task GetAllCategories_WhenCalled_ReturnsOkResult() //Get_WhenCalled_ReturnsOkResult
        {
            // Act
            var okResult = await _controller.GetAllCategories();

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}
