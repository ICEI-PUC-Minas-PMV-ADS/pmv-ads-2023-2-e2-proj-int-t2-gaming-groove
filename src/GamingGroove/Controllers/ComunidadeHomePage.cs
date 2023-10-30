using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Views.ComunidadeHomePage;
using System.Security.Claims;

namespace GamingGroove.Controllers
{
    public class ComunidadeHomePageController : BaseController
    {
        private readonly GamingGrooveDbContext _contexto;

        public ComunidadeHomePageController(GamingGrooveDbContext contexto)
        {
            _contexto = contexto;
        }

        public int IdUsuarioLogado {get; set;}

        public IActionResult Index(string community)
        {
            {
                var viewModel = new ComunidadeHomePageViewModel(_contexto);
                

                if (viewModel == null)
                {
                    return NotFound();
                }

                var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
                
                if (usuarioId.HasValue)
                {
                    IdUsuarioLogado = usuarioId.Value;
                }

                viewModel.OnGet(community);
                viewModel.GetUsuarioLogado(IdUsuarioLogado);

                return View(viewModel);
            }
        }
    }
}    