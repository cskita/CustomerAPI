using System;
using System.Net;
using CustomerAPI.Framework.Domain;
using CustomerAPI.Framework.GeneralException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerAPI.Framework.Filter
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as NotFoundException;
                context.Exception = null;

                context.Result = new JsonResult(BaseResult.NotOK(ex.Message));
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (context.Exception is BadRequestException)
            {
                var ex = context.Exception as BadRequestException;
                context.Exception = null;

                context.Result = new JsonResult(BaseResult.NotOK(ex.Message));
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is UnauthorizedException)
            {
                var ex = context.Exception as UnauthorizedException;
                context.Exception = null;

                context.Result = new JsonResult(BaseResult.NotOK(context.Exception.Message));
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is ForbiddenException)
            {
                context.Result = new JsonResult(BaseResult.NotOK(context.Exception.Message));
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else if (context.Exception is NotImplementedException)
            {
                context.Result = new JsonResult(BaseResult.NotOK(context.Exception.Message));
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
            }

            base.OnException(context);
        }
    }
}
