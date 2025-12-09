using System.Text.Json;
using TodosFinal.Models;

namespace TodosFinal.Services
{
    public class SessionManagerService : ISessionManagerService
    {
        public void Add(string key,object obj,HttpContext context)
        {
            string chaine = JsonSerializer.Serialize(obj);
            context.Session.SetString(key, chaine);

        }
        
    }
}
