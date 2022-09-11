using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using ToDoListMVC.CRUD;
using ToDoListMVC.Models;

namespace ToDoListMVC.Controllers
{

    public class ToDoController : Controller
    {
        private readonly ToDoCrud toDoCrud;
        public ToDoController(ToDoCrud toDoCrud)
        {
            this.toDoCrud = toDoCrud;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddList(string test)
        {
            ToDoHolder holder = JsonSerializer.Deserialize<ToDoHolder>(test);
            ToDoList list = new ToDoList();
            list.Name = holder.name;
            foreach (var item in holder.tasks)
            {
                list.Tasks.Add(new ToDoItem(item));
            }

            if (ModelState.IsValid)
            {
                toDoCrud.Create(list);
                return RedirectToAction(nameof(ViewLists));
            }
            return View("List", toDoCrud.GetLists());
        }
        public IActionResult ViewLists()
        {
            return View("List", toDoCrud.GetLists());
        }
        [HttpGet]
        public IActionResult ViewList(ToDoList list)
        {
            var test = toDoCrud.Get(list.Id);
            return View("WatchList", test);
        }

        [HttpPost]
        public IActionResult UpdateList(ToDoList model)
        {

            return View("WatchList", toDoCrud.Get(model.Id));
        } 
    }
}
