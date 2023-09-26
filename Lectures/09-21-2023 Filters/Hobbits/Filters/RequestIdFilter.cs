using Hobbits.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Hobbits.Filters
{
    public class RequestIdFilter : IActionFilter
    {
        private readonly IRequestIdGenerator requestIdGenerator;

        public RequestIdFilter(IRequestIdGenerator requestIdGenerator) {
            this.requestIdGenerator = requestIdGenerator;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers["request-id"] = requestIdGenerator.RequestId;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
