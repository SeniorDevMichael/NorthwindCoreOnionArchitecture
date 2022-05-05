using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NorthwindCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.WebApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public BasicAuthenticationMiddleware(RequestDelegate next,
                                             IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];

            if (authHeader!=null && authHeader.StartsWith("Basic"))
            {
                #region OLD

                /*
                string ecodeUsernameAndPassword = authHeader.Substring("Basic ".Length).Trim();

                Encoding encoding = Encoding.GetEncoding("UTF-8");

                string usernameAndPassword = encoding.GetString(Convert.FromBase64String(ecodeUsernameAndPassword));

                int index = usernameAndPassword.IndexOf(":");

                var username = usernameAndPassword.Substring(0, index);
                var password = usernameAndPassword.Substring(index + 1);
                */

                #endregion

                AuthModel authModel = Helper.GetUserInfoFromAuth(httpContext);

                //string real_username = _configuration["Authentication:username"];
                //string real_password = _configuration["Authentication:password"];

                //if (username.Equals(real_username) && password.Equals(real_password))
                if (Helper.CheckUser(authModel.username, authModel.password)) // Check username and password from Database
                {
                    await _next(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                return;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}