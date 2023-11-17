using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GamingGroove.Controllers
{
    [AllowAnonymous]
    public class AcessoNegadoPageController : Controller
    {
        public IActionResult Index()
        {           
            return View();
        }
    }
}    