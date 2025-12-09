using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using System.Text.Json;
using TodosFinal.Filters;
using TodosFinal.Mapper;
using TodosFinal.Models;
using TodosFinal.Services;
using TodosFinal.ViewModel;

namespace TodosFinal.Controllers
{
    [SessionAuthFilter]
    [ThemeFilter]
    [LoggingFilter]
    public class TodoController : Controller
    {
        ISessionManagerService session;
        public TodoController(ISessionManagerService session)
        {
            this.session = session;
        }

        public IActionResult Index()
        {
            var data = HttpContext.Session.GetString("todos");

            List<Todo> list = data == null ? new List<Todo>() : JsonSerializer.Deserialize<List<Todo>>(data);
            var lastLogout = Request.Cookies["LastLogout"];
            ViewBag.LastLogout = lastLogout ?? "Nevah";

            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(todoAddVm vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            List<Todo> list;
            if (HttpContext.Session.GetString("todos") == null)
            {
                list = new List<Todo>();
            }
            else {

                list =JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("todos"));
            }


            Todo todo = TodoMapper.GetTodoFromTodoAddVm(vm);
            list.Add(todo);
            session.Add("todos", list, HttpContext);

            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid id)
        {
            var data = HttpContext.Session.GetString("todos");
            var list = data != null
                ? JsonSerializer.Deserialize<List<Todo>>(data)
                : new List<Todo>();

            var todo = list.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            // Map to todoAddVm if needed
            var vm = new todoAddVm
            {
                Libelle = todo.Libelle,
                Description = todo.Description,
                State = todo.State,
                Datetime = todo.Datetime
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, todoAddVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var data = HttpContext.Session.GetString("todos");
            var list = data != null
                ? JsonSerializer.Deserialize<List<Todo>>(data)
                : new List<Todo>();

            var todo = list.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.Libelle = vm.Libelle;
                todo.Description = vm.Description;
                todo.State = vm.State;
                todo.Datetime = vm.Datetime;

                session.Add("todos", list, HttpContext);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var data = HttpContext.Session.GetString("todos");
            var list = data != null
                ? JsonSerializer.Deserialize<List<Todo>>(data)
                : new List<Todo>();

            var todo = list.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                list.Remove(todo);
                session.Add("todos", list, HttpContext);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
