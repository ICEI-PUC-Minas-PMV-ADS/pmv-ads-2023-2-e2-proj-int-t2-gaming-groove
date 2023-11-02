using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class PublicacaoController : BaseController
    {
        private readonly GamingGrooveDbContext _context;

        public PublicacaoController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: Publicacao
        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.Publicacoes.Include(p => p.comunidade).Include(p => p.usuario);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        // GET: Publicacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Publicacoes == null)
            {
                return NotFound();
            }

            var publicacaoModel = await _context.Publicacoes
                .Include(p => p.comunidade)
                .Include(p => p.usuario)
                .FirstOrDefaultAsync(m => m.publicacaoId == id);
            if (publicacaoModel == null)
            {
                return NotFound();
            }

            return View(publicacaoModel);
        }

        // GET: Publicacao/Create
        public IActionResult Create()
        {
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId");
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            return View();
        }

        // POST: Publicacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("publicacaoId,usuarioId,comunidadeId,textoPublicacao,midiaPublicacao,dataPublicacao")] PublicacaoModel publicacaoModel, IFormFile? midiaPublicacaoArquivo)
        {
            if (ModelState.IsValid)
            {
                if (midiaPublicacaoArquivo != null && midiaPublicacaoArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await midiaPublicacaoArquivo.CopyToAsync(memoryStream);
                        publicacaoModel.midiaPublicacao = memoryStream.ToArray();
                    }
                }   

                _context.Add(publicacaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", publicacaoModel.comunidadeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", publicacaoModel.usuarioId);
            return View(publicacaoModel);
        }

        // GET: Publicacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Publicacoes == null)
            {
                return NotFound();
            }

            var publicacaoModel = await _context.Publicacoes.FindAsync(id);
            if (publicacaoModel == null)
            {
                return NotFound();
            }
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", publicacaoModel.comunidadeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", publicacaoModel.usuarioId);
            return View(publicacaoModel);
        }

        // POST: Publicacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("publicacaoId,usuarioId,comunidadeId,textoPublicacao,midiaPublicacao,dataPublicacao")] PublicacaoModel publicacaoModel)
        {
            if (id != publicacaoModel.publicacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacaoModelExists(publicacaoModel.publicacaoId))
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
            ViewData["comunidadeId"] = new SelectList(_context.Comunidades, "comunidadeId", "comunidadeId", publicacaoModel.comunidadeId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", publicacaoModel.usuarioId);
            return View(publicacaoModel);
        }

        // GET: Publicacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Publicacoes == null)
            {
                return NotFound();
            }

            var publicacaoModel = await _context.Publicacoes
                .Include(p => p.comunidade)
                .Include(p => p.usuario)
                .FirstOrDefaultAsync(m => m.publicacaoId == id);
            if (publicacaoModel == null)
            {
                return NotFound();
            }

            return View(publicacaoModel);
        }

        // POST: Publicacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Publicacoes == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.Publicacoes'  is null.");
            }
            var publicacaoModel = await _context.Publicacoes.FindAsync(id);
            if (publicacaoModel != null)
            {
                _context.Publicacoes.Remove(publicacaoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacaoModelExists(int id)
        {
          return (_context.Publicacoes?.Any(e => e.publicacaoId == id)).GetValueOrDefault();
        }
    }
}
