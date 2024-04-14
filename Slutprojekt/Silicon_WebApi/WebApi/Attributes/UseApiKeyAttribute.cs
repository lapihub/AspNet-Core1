using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{


    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {

        var secret = "de94fdf1-37f4-40cd-b634-8a9367b98c1a";

        if (context.HttpContext.Request.Query.TryGetValue("key", out var key))
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (secret == key)
                {
                    await next();
                }
            }
        }

        context.Result = new UnauthorizedResult();
        return;
    }
}