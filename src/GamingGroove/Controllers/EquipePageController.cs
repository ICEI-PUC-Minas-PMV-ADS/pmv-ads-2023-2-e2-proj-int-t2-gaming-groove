using System.Security.Claims;
using GamingGroove.Data;
using GamingGroove.Views.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GamingGroove.Controllers
{
    public class EquipePageController : BaseController
    {
        private readonly GamingGrooveDbContext _cc;

        public EquipePageController(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            var viewModel = new ViewModel(_cc);
            var IdUsuarioLogado = HttpContext.Session.GetInt32("UsuarioId");

            viewModel.OnGetListaDeAmigos(IdUsuarioLogado);
            viewModel.OnGetEquipePage(IdUsuarioLogado);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
    }

}
