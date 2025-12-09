using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TodosFinal.Filters
{
    public class SessionAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isAuth = context.HttpContext.Session.GetString("isAuth");

            if (string.IsNullOrEmpty(isAuth))
            {
                context.Result = new RedirectToActionResult("LoginForm", "User", null);
            }
        }
    }
}
