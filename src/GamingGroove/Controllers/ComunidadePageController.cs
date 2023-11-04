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

        public async Task<IActionResult> CriarPublicacao(int? IdUsuario, int IdComunidade, string TextoPublicacao, DateTime DataComentario, IFormFile? midiaPublicacaoArquivo)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            PublicacaoModel publicacaoModel = new ()
            {
                usuarioId = (int)IdUsuario,
                comunidadeId = IdComunidade,
                textoPublicacao = TextoPublicacao,
                dataPublicacao = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                if (midiaPublicacaoArquivo != null && midiaPublicacaoArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await midiaPublicacaoArquivo.CopyToAsync(memoryStream);
                        publicacaoModel.midiaPublicacao = memoryStream.ToArray();
                    }
                }
                _context.Add(publicacaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { community = TempData["CommunityValue"] });
            }

            return RedirectToAction("Index", new { community = TempData["CommunityValue"] });
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