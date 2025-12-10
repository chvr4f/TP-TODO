using Microsoft.AspNetCore.Mvc;
using TodosFinal.Services;
using TodosFinal.ViewModel;

namespace TodosFinal.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService _auth;

        public UserController(IAuthService auth)
        {
            _auth = auth;
        }

        public IActionResult LoginForm()
        {
            return View();
        }

        public IActionResult Login(User user)
        {
            if (ModelState.IsValid && _auth.Login(user))
            {
                return RedirectToAction("Index", "Todo");
            }

            return View("LoginForm");
        }

        public IActionResult Logout()
        {
            _auth.Logout();
            return RedirectToAction("LoginForm");
        }
    }
}