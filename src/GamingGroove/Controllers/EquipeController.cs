using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class EquipeController : BaseController
    {
        private readonly GamingGrooveDbContext _context;

        public EquipeController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: Equipe
        public async Task<IActionResult> Index()
        {
              return _context.Equipes != null ? 
                          View(await _context.Equipes.ToListAsync()) :
                          Problem("Entity set 'GamingGrooveDbContext.Equipes'  is null.");
        }

        // GET: Equipe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipes == null)
            {
                return NotFound();
            }

            var equipeModel = await _context.Equipes
                .FirstOrDefaultAsync(m => m.equipeId == id);
            if (equipeModel == null)
            {
                return NotFound();
            }

            return View(equipeModel);
        }

        // GET: Equipe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("equipeId,nomeEquipe,iconeEquipe,descricaoEquipe,jogoEquipe,dataCriacaoEquipe")] EquipeModel equipeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipeModel);
        }

        // GET: Equipe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipes == null)
            {
                return NotFound();
            }

            var equipeModel = await _context.Equipes.FindAsync(id);
            if (equipeModel == null)
            {
                return NotFound();
            }
            return View(equipeModel);
        }

        // POST: Equipe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("equipeId,nomeEquipe,iconeEquipe,descricaoEquipe,jogoEquipe,dataCriacaoEquipe")] EquipeModel equipeModel)
        {
            if (id != equipeModel.equipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipeModelExists(equipeModel.equipeId))
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
            return View(equipeModel);
        }

        // GET: Equipe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipes == null)
            {
                return NotFound();
            }

            var equipeModel = await _context.Equipes
                .FirstOrDefaultAsync(m => m.equipeId == id);
            if (equipeModel == null)
            {
                return NotFound();
            }

            return View(equipeModel);
        }

        // POST: Equipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipes == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.Equipes'  is null.");
            }
            var equipeModel = await _context.Equipes.FindAsync(id);
            if (equipeModel != null)
            {
                _context.Equipes.Remove(equipeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipeModelExists(int id)
        {
          return (_context.Equipes?.Any(e => e.equipeId == id)).GetValueOrDefault();
        }
    }
}
