using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Views.Shared;
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

        public int IdUsuarioLogado { get; set; }

        public IActionResult Index(string community)
        {
            {
                var viewModel = new ViewModel(_context);
                

                if (viewModel == null)
                {
                    return NotFound();
                }

                var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
                
                if (usuarioId.HasValue)
                {
                    IdUsuarioLogado = usuarioId.Value;
                }

                viewModel.OnGetComunidadePages(community, IdUsuarioLogado);

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

        public async Task<IActionResult> Comentar(int? IdUsuario, int IdPublicacao, string TextoComentario, DateTime DataComentario)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            ComentarioModel comentarioModel = new ()
            {
                usuarioId = (int)IdUsuario,
                publicacaoId = IdPublicacao,
                textoComentario = TextoComentario,
                dataComentario = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                _context.Add(comentarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { community = TempData["CommunityValue"] });
            }

            return RedirectToAction("Index", new { community = TempData["CommunityValue"] });
        }


    
    }
}    