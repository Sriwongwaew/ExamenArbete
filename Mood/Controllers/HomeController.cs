using Microsoft.AspNetCore.Mvc;

namespace Mood.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Mood");
        }

    }
}
