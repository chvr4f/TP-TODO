using Microsoft.AspNetCore.Mvc;
using TodosFinal.ViewModel;

namespace TodosFinal.Controllers
{
    public class UserController : Controller
    {
        public IActionResult LoginForm()
        {
            return View();
        }
        public IActionResult Login(User u)  
        {
            if (ModelState.IsValid)
            {
                string password = new string(u.Password.Reverse().ToArray());
                if (u.Login == password)
                {
                    HttpContext.Session.SetString("isAuth", "true");
                    HttpContext.Session.SetString("userLogin", u.Login);
                    return RedirectToAction("Index", "Todo");
                }
            }
            return View("LoginForm");

        }
        public IActionResult Logout() {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30), 
                HttpOnly = true
            };
            Response.Cookies.Append("LastLogout", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), cookieOptions);
            HttpContext.Session.Clear();
            return RedirectToAction("LoginForm");
        }
    }
}
