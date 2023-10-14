using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: UsuarioComunidade
        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.UsuariosComunidades.Include(u => u.comunidade).Include(u => u.usuario);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        // GET: UsuarioComunidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuariosComunidades == null)
            {
                return NotFound();
            }

            var usuarioComunidadeModel = await _context.UsuariosComunidades
                .Include(u => u.comunidade)
                .Include(u => u.usuario)
                .FirstOrDefaultAsync(m => m.usuarioComunidadeId == id);
            if (usuarioComunidadeModel == null)
            {
                return NotFound();
            }

            return View(usuarioComunidadeModel);
        }

        // GET: UsuarioComunidade/Create
        public IActionResult Create()
        {
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId");
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            return View();
        }

        // POST: UsuarioComunidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("usuarioComunidadeId,usuarioId,comunidadeId,cargo,dataVinculoComunidade")] UsuarioComunidadeModel usuarioComunidadeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioComunidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", usuarioComunidadeModel.comunidadeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioComunidadeModel.usuarioId);
            return View(usuarioComunidadeModel);
        }

        // GET: UsuarioComunidade/Edit/5
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

        // POST: UsuarioComunidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("usuarioComunidadeId,usuarioId,comunidadeId,cargo,dataVinculoComunidade")] UsuarioComunidadeModel usuarioComunidadeModel)
        {
            if (id != usuarioComunidadeModel.usuarioComunidadeId)
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
                    if (!UsuarioComunidadeModelExists(usuarioComunidadeModel.usuarioComunidadeId))
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

        // GET: UsuarioComunidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuariosComunidades == null)
            {
                return NotFound();
            }

            var usuarioComunidadeModel = await _context.UsuariosComunidades
                .Include(u => u.comunidade)
                .Include(u => u.usuario)
                .FirstOrDefaultAsync(m => m.usuarioComunidadeId == id);
            if (usuarioComunidadeModel == null)
            {
                return NotFound();
            }

            return View(usuarioComunidadeModel);
        }

        // POST: UsuarioComunidade/Delete/5
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
          return (_context.UsuariosComunidades?.Any(e => e.usuarioComunidadeId == id)).GetValueOrDefault();
        }
    }
}
