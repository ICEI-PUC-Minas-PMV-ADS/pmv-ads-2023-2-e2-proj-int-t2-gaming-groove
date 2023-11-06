using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using System.Security.Claims;
using GamingGroove.Views.Shared;

namespace GamingGroove.Controllers
{
    public class ExplorarPageController : BaseController
    {
        private readonly GamingGrooveDbContext _contexto;

        public ExplorarPageController(GamingGrooveDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var viewModel = new ViewModel(_contexto);
            var IdUsuarioLogado = HttpContext.Session.GetInt32("UsuarioId");

            viewModel.OnGetListaDeAmigos(IdUsuarioLogado);
            viewModel.OnGetExplorarPage(IdUsuarioLogado);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
            
    }
}