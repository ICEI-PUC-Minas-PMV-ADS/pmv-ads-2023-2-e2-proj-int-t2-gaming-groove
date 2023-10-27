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
        public async Task<IActionResult> Create([Bind("equipeId,nomeEquipe,iconeEquipe,descricaoEquipe,jogoEquipe,dataCriacaoEquipe")] EquipeModel equipeModel, IFormFile? iconeEquipeArquivo)
        {
            if (ModelState.IsValid)
            {
                if (iconeEquipeArquivo != null && iconeEquipeArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await iconeEquipeArquivo.CopyToAsync(memoryStream);
                        equipeModel.iconeEquipe = memoryStream.ToArray();
                    }
                }
                       
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
        public async Task<IActionResult> Edit(int id, [Bind("equipeId,nomeEquipe,descricaoEquipe,jogoEquipe,dataCriacaoEquipe")] EquipeModel equipeModel, IFormFile? iconeEquipeArquivo)
        {
            if (id != equipeModel.equipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Busque a equipe existente no banco de dados
                    var existingTeam = await _context.Equipes.FindAsync(id);

                    if (existingTeam != null)
                    {
                        // Atualize as propriedades da equipe existente com base no modelo recebido
                        existingTeam.nomeEquipe = equipeModel.nomeEquipe;
                        existingTeam.descricaoEquipe = equipeModel.descricaoEquipe;
                        existingTeam.jogoEquipe = equipeModel.jogoEquipe;
                        existingTeam.dataCriacaoEquipe = equipeModel.dataCriacaoEquipe;

                        // Verifique se um novo ícone de equipe foi fornecido
                        if (iconeEquipeArquivo != null && iconeEquipeArquivo.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await iconeEquipeArquivo.CopyToAsync(memoryStream);
                                existingTeam.iconeEquipe = memoryStream.ToArray();
                            }
                        }

                        _context.Entry(existingTeam).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return NotFound(); // Equipe não encontrada no banco de dados
                    }
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
