using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindCore.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] //invisible in swagger
    public class AuthorizeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> NotAuthorized()
        {
            return Unauthorized();
        }
    }
}
