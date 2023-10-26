using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;
using GamingGroove.Views.PerfilPage;

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
        public async Task<IActionResult> Create([Bind("usuarioId,nomeUsuario,nomeCompleto,dataNascimento,email,senha,iconePerfil,capaPerfil,fotosGaleria,primeiroJogo,segundoJogo,terceiroJogo,biografia,registrationDate,tipoUsuario")] PerfilPageViewModel usuarioModel)
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

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

                    if (existingUser == null)
                    {
                        return NotFound();
                    }

                    if (iconePerfilArquivo != null && iconePerfilArquivo.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await iconePerfilArquivo.CopyToAsync(memoryStream);
                            usuarioModel.iconePerfil = memoryStream.ToArray();
                        }
                    }
                    else
                    {
                        usuarioModel.iconePerfil = existingUser.iconePerfil;
                    }

                    if (capaPerfilArquivo != null && capaPerfilArquivo.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await capaPerfilArquivo.CopyToAsync(memoryStream);
                            usuarioModel.capaPerfil = memoryStream.ToArray();
                        }   
                    }      
                    else
                    {
                        usuarioModel.iconePerfil = existingUser.iconePerfil;
                    }                          

                    if (usuarioModel.senha != existingUser.senha)
                    {
                        usuarioModel.senha = BCrypt.Net.BCrypt.HashPassword(usuarioModel.senha);
                    }
                    else
                    {
                        usuarioModel.senha = existingUser.senha;
                    }

                    usuarioModel.dataRegistro = existingUser.dataRegistro;

                    _context.Entry(existingUser).CurrentValues.SetValues(usuarioModel);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
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
