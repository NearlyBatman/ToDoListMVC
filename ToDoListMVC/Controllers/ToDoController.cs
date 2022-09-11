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
        public IActionResult AddList(string jsonList)
        {
            ToDoHolder holder = JsonSerializer.Deserialize<ToDoHolder>(jsonList);
            ToDoList list = new ToDoList();
            list.Name = holder.name;
            foreach (var item in holder.tasks)
            {
                list.Tasks.Add(new ToDoItem(item));
            }

            //toDoCrud.Create(list);
            return View();
        }
        public IActionResult ViewLists()
        {
            return View("List", toDoCrud.GetLists());
        }

        public IActionResult ViewList(ToDoList list)
        {
            return View("WatchList", toDoCrud.Get(list.Id));
        }

        [HttpPost]
        // Den binder ikke modellen og jeg forstår ikke hvorfor?!?!?
        public IActionResult UpdateList(ToDoList model)
        {

            return View("WatchList", toDoCrud.Get(model.Id));
        } 
    }
}
