using Microsoft.AspNetCore.Mvc;

namespace GamingGroove.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
