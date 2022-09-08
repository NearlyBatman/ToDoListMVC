using Microsoft.AspNetCore.Mvc;

namespace ToDoListMVC.Controllers
{

    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddList(string testing)
        {

            return Json(new { success = true, responseText = "Success" });
        }
    }
}
