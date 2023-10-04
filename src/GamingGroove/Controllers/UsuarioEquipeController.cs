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
    public class UsuarioEquipeController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public UsuarioEquipeController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: UsuarioEquipe
        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.UsuariosEquipes.Include(u => u.equipe).Include(u => u.usuario);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        // GET: UsuarioEquipe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuariosEquipes == null)
            {
                return NotFound();
            }

            var usuarioEquipeModel = await _context.UsuariosEquipes
                .Include(u => u.equipe)
                .Include(u => u.usuario)
                .FirstOrDefaultAsync(m => m.usuarioEquipeId == id);
            if (usuarioEquipeModel == null)
            {
                return NotFound();
            }

            return View(usuarioEquipeModel);
        }

        // GET: UsuarioEquipe/Create
        public IActionResult Create()
        {
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId");
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            return View();
        }

        // POST: UsuarioEquipe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("usuarioEquipeId,usuarioId,equipeId,cargoEquipe,dataVinculoEquipe")] UsuarioEquipeModel usuarioEquipeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioEquipeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId", usuarioEquipeModel.equipeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioEquipeModel.usuarioId);
            return View(usuarioEquipeModel);
        }

        // GET: UsuarioEquipe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuariosEquipes == null)
            {
                return NotFound();
            }

            var usuarioEquipeModel = await _context.UsuariosEquipes.FindAsync(id);
            if (usuarioEquipeModel == null)
            {
                return NotFound();
            }
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId", usuarioEquipeModel.equipeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", usuarioEquipeModel.usuarioId);
            return View(usuarioEquipeModel);
        }

        // POST: UsuarioEquipe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(usuarioEquipeModel);
                    await _context.SaveChangesAsync();
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

        // GET: UsuarioEquipe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuariosEquipes == null)
            {
                return NotFound();
            }

            var usuarioEquipeModel = await _context.UsuariosEquipes
                .Include(u => u.equipe)
                .Include(u => u.usuario)
                .FirstOrDefaultAsync(m => m.usuarioEquipeId == id);
            if (usuarioEquipeModel == null)
            {
                return NotFound();
            }

            return View(usuarioEquipeModel);
        }

        // POST: UsuarioEquipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuariosEquipes == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.UsuariosEquipes'  is null.");
            }
            var usuarioEquipeModel = await _context.UsuariosEquipes.FindAsync(id);
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
