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
            var IdUsuarioLogado = HttpContext.Session.GetInt32("UsuarioId");
            var viewModel = new ViewModel(_context);

            viewModel.OnGetListaDeAmigos(IdUsuarioLogado);
            viewModel.OnGetFeedPage(IdUsuarioLogado);
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


        public async Task<IActionResult> DeixarEquipe(int? IdUsuario, int IdEquipe)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var usuarioEquipeModel = await _context.UsuariosEquipes
                .FirstOrDefaultAsync(uc => uc.usuarioId == IdUsuario && uc.equipeId == IdEquipe);

            _context.UsuariosEquipes.Remove(usuarioEquipeModel);     

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "FeedPage");            
        }

        public async Task<IActionResult> ApagarEquipe(int? IdUsuario, int IdEquipe)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var equipeModel = await _context.Equipes
                .FirstOrDefaultAsync(uc => uc.equipeId == IdEquipe);

            _context.Equipes.Remove(equipeModel);     

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "FeedPage");           
        }    


        public async Task<IActionResult> EditarEquipe(int? EquipeId, string NomeEquipe, JogosEnum JogoEquipe, 
        string DescricaoEquipe, IFormFile iconeEquipeArquivo)
        {
            var existingTeam = await _context.Equipes.FindAsync(EquipeId);

            if(existingTeam != null)
            {
                existingTeam.nomeEquipe = NomeEquipe;
                existingTeam.jogoEquipe = JogoEquipe;
                existingTeam.descricaoEquipe = DescricaoEquipe;

                if (iconeEquipeArquivo != null && iconeEquipeArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await iconeEquipeArquivo.CopyToAsync(memoryStream);
                        existingTeam.iconeEquipe = memoryStream.ToArray();
                    }
                }

                 _context.Entry(existingTeam).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("Index", "FeedPage");
        }                           
    }
}