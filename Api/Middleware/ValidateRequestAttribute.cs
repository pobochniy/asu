using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Middleware;

public class ValidateRequestAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.ModelState.IsValid) return;
        context.Result = new UnprocessableEntityObjectResult(context.ModelState);
    }
}