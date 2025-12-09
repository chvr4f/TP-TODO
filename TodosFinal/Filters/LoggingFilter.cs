using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace TodosFinal.Filters
{
    public class LoggingFilter : ActionFilterAttribute
    {
        private readonly string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs.txt");

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var user = context.HttpContext.Session.GetString("userLogin") ?? "Anonymous";
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            var logLine = $"{dateTime} – {user} – {controller} – {action}";

            File.AppendAllText(logFilePath, logLine + Environment.NewLine);
        }
    }
}
