using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing.Tree;
using MyJwtKey;
using Org.BouncyCastle.Asn1.Iana;

namespace MyatributeApiKey;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class Myatribute : Attribute, IAsyncActionFilter
{

    public async Task OnActionResult(ActionExecutedContext context, ActionExecutionDelegate next)
    {
        if(!context.HttpContext.Request.Query.TryGetValue(Configuration.ApiKey,out var ExtracedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "ApiKey não encontrada"
            };
            return;

        }
        if(Configuration.ApiKey.Equals(ExtracedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 400,
                Content = "não autorizado"
            };
            return;
            
        }
        await next ();
    }
    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        throw new NotImplementedException();
    }
}