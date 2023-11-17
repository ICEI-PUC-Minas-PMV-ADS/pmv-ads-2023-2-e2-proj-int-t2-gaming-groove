using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;
using System.Security.Claims;
using GamingGroove.Views.Shared;

namespace GamingGroove.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public UsuarioController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
              return _context.Usuarios != null ? 
                          View(await _context.Usuarios.ToListAsync()) :
                          Problem("Entity set 'GamingGrooveDbContext.Usuarios'  is null.");
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.usuarioId == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("usuarioId,nomeUsuario,nomeCompleto,dataNascimento,email,senha,iconePerfil,capaPerfil,fotosGaleria,primeiroJogo,segundoJogo,terceiroJogo,biografia,registrationDate,tipoUsuario")] ViewModel usuarioModel)
        {
            
            if (ModelState.IsValid)
            {
                usuarioModel.getUsuario.senha = BCrypt.Net.BCrypt.HashPassword(usuarioModel.getUsuario.senha);
                
                if (usuarioModel.getUsuario.primeiroJogo != null && usuarioModel.getUsuario.segundoJogo != null && usuarioModel.getUsuario.terceiroJogo != null)
                {
                    if (usuarioModel.getUsuario.primeiroJogo == usuarioModel.getUsuario.segundoJogo || 
                        usuarioModel.getUsuario.primeiroJogo == usuarioModel.getUsuario.terceiroJogo || 
                        usuarioModel.getUsuario.segundoJogo == usuarioModel.getUsuario.terceiroJogo)
                    {
                        ModelState.AddModelError("", "Escolha três jogos diferentes.");
                        return View(usuarioModel);
                    }
                }
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "HomePage");
            }
            return View("Index", usuarioModel);
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

                        existingUser.primeiroJogo = usuarioModel.primeiroJogo;
                        existingUser.segundoJogo = usuarioModel.segundoJogo;
                        existingUser.terceiroJogo = usuarioModel.terceiroJogo;
                        existingUser.biografia = usuarioModel.biografia;

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

                        existingUser.nomeUsuario = usuarioModel.nomeUsuario;
                        existingUser.nomeCompleto = usuarioModel.nomeCompleto;
                        existingUser.dataNascimento = usuarioModel.dataNascimento;
                        existingUser.email = usuarioModel.email;
                        existingUser.senha = usuarioModel.senha;
                        existingUser.primeiroJogo = usuarioModel.primeiroJogo;
                        existingUser.segundoJogo = usuarioModel.segundoJogo;
                        existingUser.terceiroJogo = usuarioModel.terceiroJogo;
                        existingUser.biografia = usuarioModel.biografia;

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
                return RedirectToAction("Index");
            }
            else
            {
        }
        return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.usuarioId == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.Usuarios'  is null.");
            }
            var usuarioModel = await _context.Usuarios.FindAsync(id);
            if (usuarioModel != null)
            {
                _context.Usuarios.Remove(usuarioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.usuarioId == id)).GetValueOrDefault();
        }
    }
}
