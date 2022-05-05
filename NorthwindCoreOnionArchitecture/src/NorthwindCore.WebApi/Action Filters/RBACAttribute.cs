using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using NorthwindCore.Infrastructure;
using System;

namespace NorthwindCore.WebApi.Action_Filters
{
    public class RBACAttribute : ActionFilterAttribute //
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controller_name = (string)filterContext.RouteData.Values["Controller"];//Categories
            string action_name = (string)filterContext.RouteData.Values["Action"];//GetAllCategories

            string requiredPermission = String.Format("{0}-{1}", controller_name, action_name);//Categories-GetAllCategories

            AuthModel authModel = Helper.GetUserInfoFromAuth(filterContext.HttpContext);

            bool hasPermission = Helper.CheckUserPermissionForApi(authModel, requiredPermission);

            if (!hasPermission)
            {
                //filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "NotAuthorized" }, { "controller", "Authorize" } });
                return;
            }
        }
    }
}
