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
    public class DenunciaController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public DenunciaController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: Denuncia
        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.Denuncias.Include(d => d.comunidade).Include(d => d.denunciado).Include(d => d.denunciante).Include(d => d.publicacao);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        // GET: Denuncia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Denuncias == null)
            {
                return NotFound();
            }

            var denunciaModel = await _context.Denuncias
                .Include(d => d.comunidade)
                .Include(d => d.denunciado)
                .Include(d => d.denunciante)
                .Include(d => d.publicacao)
                .FirstOrDefaultAsync(m => m.denunciaId == id);
            if (denunciaModel == null)
            {
                return NotFound();
            }

            return View(denunciaModel);
        }

        // GET: Denuncia/Create
        public IActionResult Create()
        {
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId");
            ViewData["denunciadoId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            ViewData["denuncianteId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId");
            return View();
        }

        // POST: Denuncia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("denunciaId,denuncianteId,denunciadoId,publicacaoId,comunidadeId,descricaoDenuncia,situacaoDenuncia,dataDenuncia")] DenunciaModel denunciaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denunciaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", denunciaModel.comunidadeId);
            ViewData["denunciadoId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", denunciaModel.denunciadoId);
            ViewData["denuncianteId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", denunciaModel.denuncianteId);
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId", denunciaModel.publicacaoId);
            return View(denunciaModel);
        }

        // GET: Denuncia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Denuncias == null)
            {
                return NotFound();
            }

            var denunciaModel = await _context.Denuncias.FindAsync(id);
            if (denunciaModel == null)
            {
                return NotFound();
            }
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", denunciaModel.comunidadeId);
            ViewData["denunciadoId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", denunciaModel.denunciadoId);
            ViewData["denuncianteId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", denunciaModel.denuncianteId);
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId", denunciaModel.publicacaoId);
            return View(denunciaModel);
        }

        // POST: Denuncia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("denunciaId,denuncianteId,denunciadoId,publicacaoId,comunidadeId,descricaoDenuncia,situacaoDenuncia,dataDenuncia")] DenunciaModel denunciaModel)
        {
            if (id != denunciaModel.denunciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denunciaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenunciaModelExists(denunciaModel.denunciaId))
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
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", denunciaModel.comunidadeId);
            ViewData["denunciadoId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", denunciaModel.denunciadoId);
            ViewData["denuncianteId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", denunciaModel.denuncianteId);
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId", denunciaModel.publicacaoId);
            return View(denunciaModel);
        }

        // GET: Denuncia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Denuncias == null)
            {
                return NotFound();
            }

            var denunciaModel = await _context.Denuncias
                .Include(d => d.comunidade)
                .Include(d => d.denunciado)
                .Include(d => d.denunciante)
                .Include(d => d.publicacao)
                .FirstOrDefaultAsync(m => m.denunciaId == id);
            if (denunciaModel == null)
            {
                return NotFound();
            }

            return View(denunciaModel);
        }

        // POST: Denuncia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Denuncias == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.Denuncias'  is null.");
            }
            var denunciaModel = await _context.Denuncias.FindAsync(id);
            if (denunciaModel != null)
            {
                _context.Denuncias.Remove(denunciaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenunciaModelExists(int id)
        {
          return (_context.Denuncias?.Any(e => e.denunciaId == id)).GetValueOrDefault();
        }
    }
}
