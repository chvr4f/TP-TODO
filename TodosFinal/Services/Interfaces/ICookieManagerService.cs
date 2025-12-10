using Microsoft.AspNetCore.Http;

namespace TodosFinal.Services.Interfaces
{
    public interface ICookieManagerService
    {
        void Set(string key, string value, int days = 30, bool httpOnly = false);
        string? Get(string key);
        void Remove(string key);
    }
}