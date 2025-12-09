using Microsoft.AspNetCore.Mvc;

namespace TodosFinal.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Switch()
        {
            var currentTheme = Request.Cookies["Theme"] ?? "light";

            var newTheme = currentTheme == "light" ? "dark" : "light";

            Response.Cookies.Append("Theme", newTheme, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            });

            return RedirectToAction("Index", "Todo");
        }
    }
}
