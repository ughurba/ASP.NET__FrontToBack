using Microsoft.AspNetCore.Mvc;

namespace FrontToBackend.Areas.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
