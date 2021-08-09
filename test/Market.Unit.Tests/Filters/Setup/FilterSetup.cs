using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Market.Unit.Tests.Filters.Setup
{
    public static class FilterSetup
    {
        public static ResultExecutingContext CreateResultExecutingContext(IFilterMetadata filter)
        {
            return new ResultExecutingContext(
                CreateActionContext(),
                new[] { filter },
                new NoOpResult(),
                new object());
        }

        public static ResultExecutedContext CreateResultExecutedContext(ResultExecutingContext context)
        {
            return new ResultExecutedContext(context, context.Filters, context.Result, context.Controller);
        }

        private static ActionContext CreateActionContext()
        {
            return new ActionContext(new DefaultHttpContext(), new RouteData(), new ActionDescriptor());
        }

        private class NoOpResult : IActionResult
        {
            public Task ExecuteResultAsync(ActionContext context)
            {
                return Task.FromResult(true);
            }
        }
    }
}