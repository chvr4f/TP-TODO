using Microsoft.AspNetCore.Http;

namespace TodosFinal.Services
{
    public class CookieManagerService : ICookieManagerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieManagerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set(string key, string value, int days = 30)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(days),
                HttpOnly = true
            };

            _httpContextAccessor.HttpContext!.Response.Cookies.Append(key, value, options);
        }

       
    }
}