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
    public class CurtidaController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public CurtidaController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: Curtida
        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.Curtidas.Include(c => c.publicacao).Include(c => c.usuario);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        // GET: Curtida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Curtidas == null)
            {
                return NotFound();
            }

            var curtidaModel = await _context.Curtidas
                .Include(c => c.publicacao)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.curtidaId == id);
            if (curtidaModel == null)
            {
                return NotFound();
            }

            return View(curtidaModel);
        }

        // GET: Curtida/Create
        public IActionResult Create()
        {
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId");
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            return View();
        }

        // POST: Curtida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("curtidaId,usuarioId,publicacaoId,dataCurtida")] CurtidaModel curtidaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curtidaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId", curtidaModel.publicacaoId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", curtidaModel.usuarioId);
            return View(curtidaModel);
        }

        // GET: Curtida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Curtidas == null)
            {
                return NotFound();
            }

            var curtidaModel = await _context.Curtidas.FindAsync(id);
            if (curtidaModel == null)
            {
                return NotFound();
            }
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId", curtidaModel.publicacaoId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", curtidaModel.usuarioId);
            return View(curtidaModel);
        }

        // POST: Curtida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("curtidaId,usuarioId,publicacaoId,dataCurtida")] CurtidaModel curtidaModel)
        {
            if (id != curtidaModel.curtidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curtidaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurtidaModelExists(curtidaModel.curtidaId))
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
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId", curtidaModel.publicacaoId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", curtidaModel.usuarioId);
            return View(curtidaModel);
        }

        // GET: Curtida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Curtidas == null)
            {
                return NotFound();
            }

            var curtidaModel = await _context.Curtidas
                .Include(c => c.publicacao)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.curtidaId == id);
            if (curtidaModel == null)
            {
                return NotFound();
            }

            return View(curtidaModel);
        }

        // POST: Curtida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Curtidas == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.Curtidas'  is null.");
            }
            var curtidaModel = await _context.Curtidas.FindAsync(id);
            if (curtidaModel != null)
            {
                _context.Curtidas.Remove(curtidaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurtidaModelExists(int id)
        {
          return (_context.Curtidas?.Any(e => e.curtidaId == id)).GetValueOrDefault();
        }
    }
}
