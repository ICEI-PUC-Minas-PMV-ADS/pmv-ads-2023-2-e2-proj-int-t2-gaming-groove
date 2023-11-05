using Microsoft.AspNetCore.Mvc;
using GamingGroove.Controllers;
using GamingGroove.Data;
using GamingGroove.Views.Shared;
using GamingGroove.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingGroove
{
    public class FeedPageController : BaseController
    {

        private readonly GamingGrooveDbContext _context;

        public FeedPageController(GamingGrooveDbContext contexto)
        {
            _context = contexto;
        }        

        public IActionResult Index()
        {
            int? usuarioLogado = HttpContext.Session.GetInt32("UsuarioId");

            var viewModel = new ViewModel(_context);
            viewModel.OnGetFeedPage(usuarioLogado);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
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
                return RedirectToAction("Index", "FeedPage");
            }

            return RedirectToAction("Index", "FeedPage");
        }     

        public async Task<IActionResult> CurtirPublicacao(int? IdUsuario, int IdPublicacao)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var existingCurtida = await _context.Curtidas
                .FirstOrDefaultAsync(c => c.usuarioId == IdUsuario && c.publicacaoId == IdPublicacao);

            if (existingCurtida == null)
            {
                CurtidaModel curtidaModel = new ()
                {
                    usuarioId = (int)IdUsuario,
                    publicacaoId = IdPublicacao,
                    dataCurtida = DateTime.Now
                };

                if (ModelState.IsValid)
                {
                    _context.Add(curtidaModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "FeedPage");
                }
            }
            _context.Curtidas.Remove(existingCurtida);     
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "FeedPage"); 
        }                 
    }
}