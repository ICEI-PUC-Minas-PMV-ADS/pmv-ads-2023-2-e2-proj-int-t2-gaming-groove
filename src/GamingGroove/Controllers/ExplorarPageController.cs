using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Views.ExplorarPage;
using System.Security.Claims;

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
            var viewModel = new ExplorarPageViewModel(_contexto);
            int usuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            viewModel.GetExplorar(usuario);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
            
    }
}