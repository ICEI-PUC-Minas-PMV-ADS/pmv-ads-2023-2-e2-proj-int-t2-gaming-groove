using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using GamingGroove.Views.Shared;

namespace GamingGroove.Controllers
{
    public class PerfilPageController : BaseController
    {
        private readonly GamingGrooveDbContext _context;

        public PerfilPageController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        public int IdUsuarioLogado { get; set; }
        
        public IActionResult Index(string user)
        {
            var viewModel = new ViewModel(_context);
        
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            
            if (usuarioId.HasValue)
            {
                IdUsuarioLogado = usuarioId.Value;
            }

            viewModel.OnGetListaDeAmigos(IdUsuarioLogado);
            viewModel.OnGetPerfilPage(user, IdUsuarioLogado);
            
            if (viewModel == null)
            {
                return NotFound();
            }
            TempData["UserValue"] = user;

            return View(viewModel);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value == id.ToString())
            {
                if (id == null || _context.Usuarios == null)
                {
                    return NotFound();
                }

                var usuarioModel = await _context.Usuarios.FindAsync(id);
                if (usuarioModel == null)
                {
                    return NotFound();
                }
                return View(usuarioModel);                    
            }
            else
            {
                return RedirectToAction("Index", "AcessoNegadoPage");
            }  
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioModel usuarioModel, IFormFile? iconePerfilArquivo, IFormFile? capaPerfilArquivo)
        {
            if (id != usuarioModel.usuarioId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = await _context.Usuarios.FindAsync(id);

                    if (existingUser != null)
                    {
                        existingUser.nomeCompleto = usuarioModel.nomeCompleto;
                        existingUser.dataNascimento = usuarioModel.dataNascimento;
                        existingUser.email = usuarioModel.email;
                        existingUser.senha = usuarioModel.senha;
                        existingUser.primeiroJogo = usuarioModel.primeiroJogo;
                        existingUser.segundoJogo = usuarioModel.segundoJogo;
                        existingUser.terceiroJogo = usuarioModel.terceiroJogo;
                        existingUser.biografia = usuarioModel.biografia;

                        if (existingUser.primeiroJogo == existingUser.segundoJogo
                        || existingUser.primeiroJogo == existingUser.terceiroJogo
                        ||existingUser.segundoJogo == existingUser.terceiroJogo)
                        {
                            ViewBag.Message = "* Selecione apenas jogos diferentes.";
                            return View(usuarioModel);
                        }

                        if (iconePerfilArquivo != null && iconePerfilArquivo.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await iconePerfilArquivo.CopyToAsync(memoryStream);
                                existingUser.iconePerfil = memoryStream.ToArray();
                            }
                        }

                        if (capaPerfilArquivo != null && capaPerfilArquivo.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await capaPerfilArquivo.CopyToAsync(memoryStream);
                                existingUser.capaPerfil = memoryStream.ToArray();
                            }
                        }
                        
                        if(existingUser.nomeUsuario != usuarioModel.nomeUsuario)
                        {
                            existingUser.nomeUsuario = usuarioModel.nomeUsuario;

                            _context.Entry(existingUser).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            await HttpContext.SignOutAsync();
      
                            return RedirectToAction("Index", "HomePage");                     
                        }

                        _context.Entry(existingUser).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.usuarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction("Index", "PerfilPage", new { user = usuarioModel.nomeUsuario });
            }
            else
            {
        }
        return View(usuarioModel);
        }

        private bool UsuarioModelExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.usuarioId == id)).GetValueOrDefault();
        }


        public async Task<IActionResult> SolicitarAmizade(int? IdUsuario, int IdUsuarioPagina)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");


                AmizadeModel amizadeModel = new ()
                {
                    solicitanteId = (int)IdUsuario,
                    receptorId = IdUsuarioPagina,
                    estadoAmizade = EstadoAmizade.Pendente,
                    dataAmizade = DateTime.Now
                };

            if (ModelState.IsValid)
            {
                _context.Add(amizadeModel);     
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PerfilPage", new { user = TempData["UserValue"] });
            }

            return RedirectToAction("Index", "PerfilPage", new { user = TempData["UserValue"] });
        }

        public async Task<IActionResult> DesfazerAmizade(int? IdUsuario, int IdUsuarioPagina)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var existingAmizade = await _context.Amizades
                .FirstOrDefaultAsync(c => c.solicitanteId == IdUsuario && c.receptorId == IdUsuarioPagina
                || c.solicitanteId == IdUsuarioPagina && c.receptorId == IdUsuario);


            if (existingAmizade != null)
            {
                _context.Amizades.Remove(existingAmizade);     
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index", "PerfilPage", new { user = TempData["UserValue"] });
            }
            
            return RedirectToAction("Index", "PerfilPage", new { user = TempData["UserValue"] });
        }

        public async Task<IActionResult> EditarPerfil(int? IdUsuario, string NomeUsuario, string NomeCompleto, DateTime DataNascimento, string Email,
        string Senha, JogosEnum PrimeiroJogo, JogosEnum SegundoJogo, JogosEnum TerceiroJogo, string Biografia, IFormFile IconePerfilArquivo, IFormFile CapaPerfilArquivo)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var existingUser = await _context.Usuarios.FindAsync(IdUsuario);

            if(existingUser != null)
            {
                existingUser.nomeUsuario = NomeUsuario;
                existingUser.nomeCompleto = NomeCompleto;
                existingUser.dataNascimento = DataNascimento;
                existingUser.email = Email;
                existingUser.senha = Senha;
                existingUser.primeiroJogo = PrimeiroJogo;
                existingUser.segundoJogo = SegundoJogo;
                existingUser.terceiroJogo = TerceiroJogo;
                existingUser.biografia = Biografia;

                if (IconePerfilArquivo != null && IconePerfilArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await IconePerfilArquivo.CopyToAsync(memoryStream);
                        existingUser.iconePerfil = memoryStream.ToArray();
                    }
                }

                if (CapaPerfilArquivo != null && CapaPerfilArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await CapaPerfilArquivo.CopyToAsync(memoryStream);
                        existingUser.capaPerfil = memoryStream.ToArray();
                    }
                }

                 _context.Entry(existingUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("Index", "PerfilPage", new { user = existingUser.nomeUsuario });
        }

        public async Task<IActionResult> AceitarAmizade(int? IdUsuario, int SolicitanteId, int ReceptorId, EstadoAmizade EstadoAmizade, DateTime DataAmizade)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var findIdAmizade = _context.Amizades.FirstOrDefault(u => u.solicitanteId == SolicitanteId && u.receptorId == IdUsuario);

            var existingAmizade = await _context.Amizades.FindAsync(findIdAmizade.amizadeId);

            if(existingAmizade != null)
            {
                existingAmizade.solicitanteId = SolicitanteId;
                existingAmizade.receptorId = (int)IdUsuario;
                existingAmizade.estadoAmizade = EstadoAmizade.Aceita;
                existingAmizade.dataAmizade = DateTime.Now;


                 _context.Entry(existingAmizade).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            var IdSolicitante = _context.Usuarios.FirstOrDefault(u => u.usuarioId == SolicitanteId);
            
            return RedirectToAction("Index", "PerfilPage", new { user = IdSolicitante.nomeUsuario });
        }

        public async Task<IActionResult> RecusarAmizade(int? IdUsuario, int SolicitanteId)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var findIdAmizade = _context.Amizades.FirstOrDefault(u => u.solicitanteId == SolicitanteId && u.receptorId == IdUsuario);

            var existingAmizade = await _context.Amizades.FindAsync(findIdAmizade.amizadeId);

            if (existingAmizade != null)
            {
                _context.Amizades.Remove(existingAmizade);     
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index", "FeedPage");
            }
            
            return RedirectToAction("Index", "FeedPage");
        }        
    }
}
