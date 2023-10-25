using Microsoft.AspNetCore.Mvc;
using GamingGroove.Controllers;

namespace GamingGroove
{
    public class FeedPageController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}