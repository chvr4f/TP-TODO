using Microsoft.AspNetCore.Http;
using TodosFinal.Services.Interfaces;



namespace TodosFinal.Services
{
    public class CookieManagerService : ICookieManagerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieManagerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set(string key, string value, int days = 30, bool httpOnly = false)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(days),
                HttpOnly = httpOnly,
                Secure = false 
            };

            _httpContextAccessor.HttpContext!.Response.Cookies.Append(key, value, options);
        }

        public string? Get(string key)
        {
            return _httpContextAccessor.HttpContext!.Request.Cookies[key];
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext!.Response.Cookies.Delete(key);
        }
    }
}