using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class UsuarioComunidadeController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public UsuarioComunidadeController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.UsuariosComunidades.Include(t => t.comunidade).Include(t => t.usuario);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuariosComunidades == null)
            {
                return NotFound();
            }

            var usuarioComunidadeModel = await _context.UsuariosComunidades
                .Include(t => t.comunidade)
                .Include(t => t.usuario)
                .FirstOrDefaultAsync(m => m.usuarioId == id);
            if (usuarioComunidadeModel == null)
            {
                return NotFound();
            }

            return View(usuarioComunidadeModel);
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

                _context.Add(usuarioComunidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", usuarioComunidadeModel.comunidadeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioComunidadeModel.usuarioId);
            return View(usuarioComunidadeModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuariosComunidades == null)
            {
                return NotFound();
            }

            var usuarioComunidadeModel = await _context.UsuariosComunidades.FindAsync(id);
            if (usuarioComunidadeModel == null)
            {
                return NotFound();
            }
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", usuarioComunidadeModel.comunidadeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioComunidadeModel.usuarioId);
            return View(usuarioComunidadeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("usuarioComunidadeId,usuarioId,comunidadeId,cargoComunidade,dataVinculoComunidade")] UsuarioComunidadeModel usuarioComunidadeModel)
        {
            if (id != usuarioComunidadeModel.usuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioComunidadeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioComunidadeModelExists(usuarioComunidadeModel.usuarioId))
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
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", usuarioComunidadeModel.comunidadeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioComunidadeModel.usuarioId);
            return View(usuarioComunidadeModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuariosComunidades == null)
            {
                return NotFound();
            }

            var usuarioComunidadeModel = await _context.UsuariosComunidades
                .Include(t => t.comunidade)
                .Include(t => t.usuario)
                .FirstOrDefaultAsync(m => m.usuarioComunidadeId == id);
            if (usuarioComunidadeModel == null)
            {
                return NotFound();
            }

            return View(usuarioComunidadeModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuariosComunidades == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.UsuariosComunidades'  is null.");
            }
            var usuarioComunidadeModel = await _context.UsuariosComunidades.FindAsync(id);
            if (usuarioComunidadeModel != null)
            {
                _context.UsuariosComunidades.Remove(usuarioComunidadeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioComunidadeModelExists(int id)
        {
          return (_context.UsuariosComunidades?.Any(e => e.usuarioId == id)).GetValueOrDefault();
        }
    }
}