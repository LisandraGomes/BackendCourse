using Microsoft.AspNetCore.Mvc;

namespace BlogApiEF.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
