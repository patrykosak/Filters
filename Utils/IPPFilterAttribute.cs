using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Utils
{
    public class IPPFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result;

            if (result is PageResult)
            {
                var page = ((PageResult)result);
                page.ViewData["filterMessage"] = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4();
            }
            await next.Invoke();
        }
    }

}

