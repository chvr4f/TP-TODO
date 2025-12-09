using Microsoft.AspNetCore.Mvc.Filters;

namespace TodosFinal.Filters
{
    public class ThemeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var theme = context.HttpContext.Request.Cookies["Theme"] ?? "light";
            context.HttpContext.Items["Theme"] = theme; 
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is Microsoft.AspNetCore.Mvc.ViewResult viewResult)
            {
                if (context.HttpContext.Items.ContainsKey("Theme"))
                {
                    viewResult.ViewData["Theme"] = context.HttpContext.Items["Theme"];
                }
            }
        }
    }
}
