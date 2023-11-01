using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Views.ComunidadePage;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class ComunidadePageController : BaseController
    {
        private readonly GamingGrooveDbContext _context;

        public ComunidadePageController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        public int IdUsuarioLogado {get; set;}
        public ComunidadeModel Community { get; set; }

        public IActionResult Index(string community)
        {
            {
                var viewModel = new ComunidadePageViewModel(_context);
                

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

                TempData["CommunityValue"] = community;

                return View(viewModel);
            }
        }

        public IActionResult Create()
        {
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId");
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("usuarioId,comunidadeId,cargoComunidade,dataVinculoComunidade")] UsuarioComunidadeModel usuarioComunidadeModel)
        {
            if (ModelState.IsValid)
            {
                var ultimoUsuarioComunidadeId = _context.UsuariosComunidades
                    .OrderByDescending(uc => uc.usuarioComunidadeId)
                    .FirstOrDefault()?.usuarioComunidadeId ?? 0;

                usuarioComunidadeModel.usuarioComunidadeId = ultimoUsuarioComunidadeId + 1;

                var comunidade = _context.Comunidades.FirstOrDefault(c => c.comunidadeId == usuarioComunidadeModel.comunidadeId);

                _context.Add(usuarioComunidadeModel);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "ComunidadePage", new { community = comunidade.nomeComunidade });
            }
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", usuarioComunidadeModel.comunidadeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioComunidadeModel.usuarioId);
            return View(usuarioComunidadeModel);
        }
    }
}    