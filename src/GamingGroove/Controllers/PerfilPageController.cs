using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Views.PerfilPage;

namespace GamingGroove.Controllers
{
    public class PerfilPageController : BaseController
    {
        private readonly GamingGrooveDbContext _contexto;

        public PerfilPageController(GamingGrooveDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index(string user)
        {
            var viewModel = new PerfilPageViewModel(_contexto);
            viewModel.OnGet(user);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
    }
}
