using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Views.Shared;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using GamingGroove.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingGroove.Controllers
{
    public class ComunidadePageController : BaseController
    {
        private readonly GamingGrooveDbContext _context;

        public ComunidadePageController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string community)
        {
            {
                var viewModel = new ViewModel(_context);
                

                if (viewModel == null)
                {
                    return NotFound();
                }

                var IdUsuarioLogado = HttpContext.Session.GetInt32("UsuarioId");
                

                viewModel.OnGetListaDeAmigos(IdUsuarioLogado);
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

        public async Task<IActionResult> ApagarPublicacao(int IdPublicacao)
        {
            var publicacaoModel = await _context.Publicacoes
                .FirstOrDefaultAsync(uc => uc.publicacaoId == IdPublicacao);

            if(publicacaoModel != null)
            {
                _context.Publicacoes.Remove(publicacaoModel);     
                await _context.SaveChangesAsync();
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

        public async Task<IActionResult> IngressarComunidade(int? IdUsuario, int IdComunidade)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            UsuarioComunidadeModel usuarioComunidadeModel = new ()
            {
                usuarioId = (int)IdUsuario,
                comunidadeId = IdComunidade,
                cargoComunidade = CargosEnum.Membro,
                dataVinculoComunidade = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                var ultimoUsuarioComunidadeId = _context.UsuariosComunidades
                    .OrderByDescending(uc => uc.usuarioComunidadeId)
                    .FirstOrDefault()?.usuarioComunidadeId ?? 0;

                usuarioComunidadeModel.usuarioComunidadeId = ultimoUsuarioComunidadeId + 1;

                _context.Add(usuarioComunidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { community = TempData["CommunityValue"] });
            }

            return RedirectToAction("Index", new { community = TempData["CommunityValue"] });
        }        


        public async Task<IActionResult> DeixarComunidade(int? IdUsuario, int IdComunidade)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var usuarioComunidadeModel = await _context.UsuariosComunidades
                .FirstOrDefaultAsync(uc => uc.usuarioId == IdUsuario && uc.comunidadeId == IdComunidade);

            _context.UsuariosComunidades.Remove(usuarioComunidadeModel);     

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { community = TempData["CommunityValue"] });            
        }

        public async Task<IActionResult> EditarComunidade(int? ComunidadeId, string NomeComunidade, JogosEnum PrimeiroJogo, 
        JogosEnum SegundoJogo, JogosEnum TerceiroJogo, string DescricaoComunidade, IFormFile iconeComunidadeArquivo, IFormFile capaComunidadeArquivo)
        {
            var existingCommunity = await _context.Comunidades.FindAsync(ComunidadeId);

            if(existingCommunity != null)
            {
                existingCommunity.nomeComunidade = NomeComunidade;
                existingCommunity.primeiroJogo = PrimeiroJogo;
                existingCommunity.segundoJogo = SegundoJogo;
                existingCommunity.terceiroJogo = TerceiroJogo;
                existingCommunity.descricaoComunidade = DescricaoComunidade;

                if (iconeComunidadeArquivo != null && iconeComunidadeArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await iconeComunidadeArquivo.CopyToAsync(memoryStream);
                        existingCommunity.iconeComunidade = memoryStream.ToArray();
                    }
                }

                if (capaComunidadeArquivo != null && capaComunidadeArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await capaComunidadeArquivo.CopyToAsync(memoryStream);
                        existingCommunity.capaComunidade = memoryStream.ToArray();
                    }
                }

                 _context.Entry(existingCommunity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("Index", "ComunidadePage", new { community = existingCommunity.nomeComunidade });
        }        

        public async Task<IActionResult> ApagarComunidade(int? IdUsuario, int IdComunidade)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var comunidadeModel = await _context.Comunidades
                .FirstOrDefaultAsync(uc => uc.comunidadeId == IdComunidade);

            _context.Comunidades.Remove(comunidadeModel);     

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "ComunidadeHomePage");           
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
                    return RedirectToAction("Index", new { community = TempData["CommunityValue"] });
                }
            }
            _context.Curtidas.Remove(existingCurtida);     
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { community = TempData["CommunityValue"] });     
        }            
    }
}    