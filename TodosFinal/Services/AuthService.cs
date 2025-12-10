using Microsoft.AspNetCore.Http;
using TodosFinal.Services.Interfaces;
using TodosFinal.ViewModel;

namespace TodosFinal.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICookieManagerService _cookieManager;

        public AuthService(IHttpContextAccessor accessor, ICookieManagerService cookieManager)
        {
            _contextAccessor = accessor;
            _cookieManager = cookieManager;
        }

        public bool Login(User user)
        {
            string reversed = new string(user.Password.Reverse().ToArray());

            if (reversed == user.Login)
            {
                _contextAccessor.HttpContext!.Session.SetString("isAuth", "true");
                _contextAccessor.HttpContext!.Session.SetString("userLogin", user.Login);
                return true;
            }

            return false;
        }

        public void Logout()
        {
            string logoutDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _cookieManager.Set("LastLogout", logoutDate, 30, httpOnly: false);

            _contextAccessor.HttpContext!.Session.Clear();
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext!.Session.GetString("isAuth") == "true";
        }

        public string? GetCurrentUserLogin()
        {
            return _contextAccessor.HttpContext!.Session.GetString("userLogin");
        }
    }
}