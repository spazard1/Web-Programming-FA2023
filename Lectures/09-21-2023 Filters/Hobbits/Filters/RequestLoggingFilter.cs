using Hobbits.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Hobbits.Filters
{
    public class RequestLoggingFilter : IActionFilter
    {
        private readonly HobbitLogger hobbitLogger;

        public RequestLoggingFilter(HobbitLogger hobbitLogger) {
            this.hobbitLogger = hobbitLogger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.hobbitLogger.Log("Finishing " + context.HttpContext.Request.Method + " " + context.HttpContext.Request.Path);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this.hobbitLogger.Log("Starting " + context.HttpContext.Request.Method + " " + context.HttpContext.Request.Path);
        }
    }
}
