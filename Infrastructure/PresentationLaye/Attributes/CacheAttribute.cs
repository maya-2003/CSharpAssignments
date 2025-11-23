using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstractionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLaye.Attributes
{
    public class CacheAttribute(int durationInSec = 100) : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheKey = CreateCacheKey(context.HttpContext.Request);
            var _cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var cacheValue = await _cacheService.GetAsync(cacheKey);
            if (cacheValue is not null) {
                context.Result = new ContentResult()
                {
                    Content = cacheValue,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK

                };
                return;
            }
            var executedContext= await next.Invoke();
            if (executedContext.Result is OkObjectResult result)
            {
                await _cacheService.SetAsync(cacheKey, result.Value, TimeSpan.FromSeconds(durationInSec));
            }
        }
        private string CreateCacheKey(HttpRequest request)
        {
            StringBuilder key = new StringBuilder();
            key.Append(request.Path+"?");
            foreach (var item in request.Query.OrderBy(q => q.Key))
            {
                key.Append($"{item.Key}={item.Value}&");
            }
            return key.ToString();

        }
    }
}
