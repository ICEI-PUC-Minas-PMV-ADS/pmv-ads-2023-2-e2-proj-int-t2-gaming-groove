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
            int usuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            viewModel.OnGetExplorarPage(usuario);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
            
    }
}