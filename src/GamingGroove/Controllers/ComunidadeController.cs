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
    public class ComunidadeController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public ComunidadeController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: Comunidade
        public async Task<IActionResult> Index()
        {
              return _context.Comunidades != null ? 
                          View(await _context.Comunidades.ToListAsync()) :
                          Problem("Entity set 'GamingGrooveDbContext.Comunidades'  is null.");
        }

        // GET: Comunidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comunidades == null)
            {
                return NotFound();
            }

            var comunidadeModel = await _context.Comunidades
                .FirstOrDefaultAsync(m => m.comunidadeId == id);
            if (comunidadeModel == null)
            {
                return NotFound();
            }

            return View(comunidadeModel);
        }

        // GET: Comunidade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comunidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("comunidadeId,nomeComunidade,iconeComunidade,capaComunidade,primeiroJogo,segundoJogo,terceiroJogo,descricaoComunidade,dataCriacaoComunidade")] ComunidadeModel comunidadeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comunidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comunidadeModel);
        }

        // GET: Comunidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comunidades == null)
            {
                return NotFound();
            }

            var comunidadeModel = await _context.Comunidades.FindAsync(id);
            if (comunidadeModel == null)
            {
                return NotFound();
            }
            return View(comunidadeModel);
        }

        // POST: Comunidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("comunidadeId,nomeComunidade,iconeComunidade,capaComunidade,primeiroJogo,segundoJogo,terceiroJogo,descricaoComunidade,dataCriacaoComunidade")] ComunidadeModel comunidadeModel)
        {
            if (id != comunidadeModel.comunidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comunidadeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComunidadeModelExists(comunidadeModel.comunidadeId))
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
            return View(comunidadeModel);
        }

        // GET: Comunidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comunidades == null)
            {
                return NotFound();
            }

            var comunidadeModel = await _context.Comunidades
                .FirstOrDefaultAsync(m => m.comunidadeId == id);
            if (comunidadeModel == null)
            {
                return NotFound();
            }

            return View(comunidadeModel);
        }

        // POST: Comunidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comunidades == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.Comunidades'  is null.");
            }
            var comunidadeModel = await _context.Comunidades.FindAsync(id);
            if (comunidadeModel != null)
            {
                _context.Comunidades.Remove(comunidadeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComunidadeModelExists(int id)
        {
          return (_context.Comunidades?.Any(e => e.comunidadeId == id)).GetValueOrDefault();
        }
    }
}
