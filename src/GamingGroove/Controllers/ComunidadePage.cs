using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Views.ComunidadePage;
using System.Security.Claims;

namespace GamingGroove.Controllers
{
    public class ComunidadePageController : BaseController
    {
        private readonly GamingGrooveDbContext _contexto;

        public ComunidadePageController(GamingGrooveDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index(string community)
        {
        {
            var viewModel = new ComunidadePageViewModel(_contexto);
            if (viewModel == null)
            {
                return NotFound();
            }
            viewModel.OnGet(community);

            return View(viewModel);
        }
            
        }
    }
}    