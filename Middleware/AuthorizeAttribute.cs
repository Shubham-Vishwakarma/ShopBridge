using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BuildRestApiNetCore.Models;

namespace BuildRestApiNetCore.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"];
            if(user == null || (Customer)user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}