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

        public IActionResult Index()
        {
            var viewModel = new ComunidadePageViewModel(_contexto);
            int usuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            viewModel.GetComunidadesUsuario(usuario);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
            
    }
}