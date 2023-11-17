using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class UsuarioEquipeController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public UsuarioEquipeController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.UsuariosEquipes.Include(t => t.equipe).Include(t => t.usuario);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuariosEquipes == null)
            {
                return NotFound();
            }

            var usuarioEquipeModel = await _context.UsuariosEquipes
                .Include(t => t.equipe)
                .Include(t => t.usuario)
                .FirstOrDefaultAsync(m => m.usuarioId == id);
            if (usuarioEquipeModel == null)
            {
                return NotFound();
            }

            return View(usuarioEquipeModel);
        }

        public IActionResult Create()
        {
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId");
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("usuarioEquipeId,usuarioId,equipeId,cargoEquipe,dataVinculoEquipe")] UsuarioEquipeModel usuarioEquipeModel)
        {
            if (ModelState.IsValid)
            {

                var ultimoRegistroEquipeId = _context.UsuariosEquipes
                    .OrderByDescending(uc => uc.usuarioEquipeId)
                    .FirstOrDefault()?.usuarioEquipeId ?? 0;

                usuarioEquipeModel.usuarioEquipeId = ultimoRegistroEquipeId + 1;   

                _context.Add(usuarioEquipeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId", usuarioEquipeModel.equipeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioEquipeModel.usuarioId);
            return View(usuarioEquipeModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuariosEquipes == null)
            {
                return NotFound();
            }

            var usuarioEquipeModel = await _context.UsuariosEquipes
                .FirstOrDefaultAsync(uc => uc.usuarioEquipeId == id);
            if (usuarioEquipeModel == null)
            {
                return NotFound();
            }
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId", usuarioEquipeModel.equipeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioEquipeModel.usuarioId);
            return View(usuarioEquipeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("usuarioEquipeId,usuarioId,equipeId,cargoEquipe,dataVinculoEquipe")] UsuarioEquipeModel usuarioEquipeModel)
        {
            if (id != usuarioEquipeModel.usuarioEquipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingUsuarioEquipe = await _context.UsuariosEquipes.FirstOrDefaultAsync(uc => uc.usuarioEquipeId == id);

                    if (existingUsuarioEquipe != null)
                    {
                        existingUsuarioEquipe.usuarioId = usuarioEquipeModel.usuarioId;
                        existingUsuarioEquipe.equipeId = usuarioEquipeModel.equipeId;
                        existingUsuarioEquipe.cargoEquipe = usuarioEquipeModel.cargoEquipe;
                        
                        _context.Update(existingUsuarioEquipe);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioEquipeModelExists(usuarioEquipeModel.usuarioEquipeId))
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
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId", usuarioEquipeModel.equipeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioEquipeModel.usuarioId);
            return View(usuarioEquipeModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuariosEquipes == null)
            {
                return NotFound();
            }

            var usuarioEquipeModel = await _context.UsuariosEquipes
                .Include(t => t.equipe)
                .Include(t => t.usuario)
                .FirstOrDefaultAsync(m => m.usuarioEquipeId == id);
            if (usuarioEquipeModel == null)
            {
                return NotFound();
            }

            return View(usuarioEquipeModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuariosEquipes == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.UsuariosEquipes'  is null.");
            }
            var usuarioEquipeModel = await _context.UsuariosEquipes
                .FirstOrDefaultAsync(uc => uc.usuarioEquipeId == id);
            if (usuarioEquipeModel != null)
            {
                _context.UsuariosEquipes.Remove(usuarioEquipeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioEquipeModelExists(int id)
        {
          return (_context.UsuariosEquipes?.Any(e => e.usuarioEquipeId == id)).GetValueOrDefault();
        }
    }
}