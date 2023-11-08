using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class AmizadeController : BaseController
    {
        private readonly GamingGrooveDbContext _context;

        public AmizadeController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: Amizade
        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.Amizades.Include(a => a.receptor).Include(a => a.solicitante);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        // GET: Amizade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Amizades == null)
            {
                return NotFound();
            }

            var amizadeModel = await _context.Amizades
                .Include(a => a.receptor)
                .Include(a => a.solicitante)
                .FirstOrDefaultAsync(m => m.amizadeId == id);
            if (amizadeModel == null)
            {
                return NotFound();
            }

            return View(amizadeModel);
        }

        // GET: Amizade/Create
        public IActionResult Create()
        {
            ViewData["receptorId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            ViewData["solicitanteId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            return View();
        }

        // POST: Amizade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("amizadeId,solicitanteId,receptorId,estadoAmizade,dataAmizade")] AmizadeModel amizadeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amizadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["receptorId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", amizadeModel.receptorId);
            ViewData["solicitanteId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", amizadeModel.solicitanteId);
            return View(amizadeModel);
        }

        // GET: Amizade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Amizades == null)
            {
                return NotFound();
            }

            var amizadeModel = await _context.Amizades.FindAsync(id);
            if (amizadeModel == null)
            {
                return NotFound();
            }
            ViewData["receptorId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", amizadeModel.receptorId);
            ViewData["solicitanteId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", amizadeModel.solicitanteId);
            return View(amizadeModel);
        }

        // POST: Amizade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("amizadeId,solicitanteId,receptorId,estadoAmizade,dataAmizade")] AmizadeModel amizadeModel)
        {
            if (id != amizadeModel.amizadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amizadeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmizadeModelExists(amizadeModel.amizadeId))
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
            ViewData["receptorId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", amizadeModel.receptorId);
            ViewData["solicitanteId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", amizadeModel.solicitanteId);
            return View(amizadeModel);
        }

        // GET: Amizade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Amizades == null)
            {
                return NotFound();
            }

            var amizadeModel = await _context.Amizades
                .Include(a => a.receptor)
                .Include(a => a.solicitante)
                .FirstOrDefaultAsync(m => m.amizadeId == id);
            if (amizadeModel == null)
            {
                return NotFound();
            }

            return View(amizadeModel);
        }

        // POST: Amizade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Amizades == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.Amizades'  is null.");
            }
            var amizadeModel = await _context.Amizades.FindAsync(id);
            if (amizadeModel != null)
            {
                _context.Amizades.Remove(amizadeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmizadeModelExists(int id)
        {
          return (_context.Amizades?.Any(e => e.amizadeId == id)).GetValueOrDefault();
        }





    }
}
