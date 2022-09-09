using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ToDoListMVC.Controllers
{

    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddList(string test)
        {
            var kek = JsonSerializer.Deserialize<string[]>(test);
            return View();
        }
    }
}
