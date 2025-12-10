using Microsoft.AspNetCore.Http;

namespace TodosFinal.Services
{
    public interface ICookieManagerService
    {
        void Set(string key, string value, int days = 30);
      
    }
}