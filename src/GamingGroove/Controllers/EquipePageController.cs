using GamingGroove.Data;
using GamingGroove.Views.EquipePage;
using Microsoft.AspNetCore.Mvc;

namespace GamingGroove.Controllers
{
    public class EquipePageController : Controller
    {
        private readonly GamingGrooveDbContext _cc;

        public EquipePageController(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index(string user)
        {
            var viewModel = new EquipePageViewModel(_cc);
            viewModel.Teste(user);
            return View(viewModel);
        }
    }
}
