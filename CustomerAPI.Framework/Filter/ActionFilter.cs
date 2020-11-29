using CustomerAPI.Framework.Domain;
using CustomerAPI.Framework.GeneralException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;

namespace CustomerAPI.Framework.Filter
{
    public class ActionFilter : ActionFilterAttribute, IResourceFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (context.Result is BadRequestObjectResult)
            {
                BadRequest(context);
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string menssage = ProcessRouteData(context.RouteData);
        }

        private string ProcessRouteData(RouteData routeData)
        {
            string menssage = null;
            routeData.Values.ToList().ForEach(data => {
                if (data.Key.EndsWith("id", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        Convert.ToInt32(data.Value.ToString());
                    }
                    catch (Exception e)
                    {
                        menssage = e.Message;
                    }
                }
            });

            return menssage;
        }

        private void BadRequest(ResourceExecutedContext context)
        {
            if (context.Result is BadRequestObjectResult)
            {
                var result = (BadRequestObjectResult)context.Result;
                var details = (ValidationProblemDetails)result.Value;

                var ex = context.Exception as BadRequestException;
                context.Exception = null;

                context.Result = new JsonResult(BaseResult.NotOK(details.Errors.First().Value.First() + ";" + details.Errors.First().Value.First()));
            }
        }
    }
}
