using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ActivityPlanner.API.Attributes
{
    public class LogActionAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService(typeof(ILogger<LogActionAttribute>)) as ILogger;
            var actionName = context.ActionDescriptor.DisplayName;
            
            var controllerName = context.RouteData.Values["controller"];
            var actionMethod = context.RouteData.Values["action"]; 

            logger?.LogInformation($"[Start] {controllerName}.{actionMethod} is starting!");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService(typeof(ILogger<LogActionAttribute>)) as ILogger;
            var actionName = context.ActionDescriptor.DisplayName;

            var controllerName = context.RouteData.Values["controller"];
            var actionMethod = context.RouteData.Values["action"];

            logger?.LogInformation($"[End] {controllerName}.{actionMethod} has finished!");
        }
    }
}
