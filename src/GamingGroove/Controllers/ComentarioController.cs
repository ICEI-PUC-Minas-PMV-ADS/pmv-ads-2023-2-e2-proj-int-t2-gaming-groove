using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class ComentarioController : BaseController
    {
        private readonly GamingGrooveDbContext _context;

        public ComentarioController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: Comentario
        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.Comentarios.Include(c => c.publicacao).Include(c => c.usuario);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        // GET: Comentario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comentarios == null)
            {
                return NotFound();
            }

            var comentarioModel = await _context.Comentarios
                .Include(c => c.publicacao)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.comentarioId == id);
            if (comentarioModel == null)
            {
                return NotFound();
            }

            return View(comentarioModel);
        }

        // GET: Comentario/Create
        public IActionResult Create()
        {
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId");
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId");
            return View();
        }

        // POST: Comentario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("comentarioId,usuarioId,publicacaoId,textoComentario,midiaComentario,dataComentario")] ComentarioModel comentarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId", comentarioModel.publicacaoId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", comentarioModel.usuarioId);
            return View(comentarioModel);
        }

        // GET: Comentario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comentarios == null)
            {
                return NotFound();
            }

            var comentarioModel = await _context.Comentarios.FindAsync(id);
            if (comentarioModel == null)
            {
                return NotFound();
            }
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId", comentarioModel.publicacaoId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", comentarioModel.usuarioId);
            return View(comentarioModel);
        }

        // POST: Comentario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("comentarioId,usuarioId,publicacaoId,textoComentario,midiaComentario,dataComentario")] ComentarioModel comentarioModel)
        {
            if (id != comentarioModel.comentarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioModelExists(comentarioModel.comentarioId))
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
            ViewData["publicacaoId"] = new SelectList(_context.Publicacoes, "publicacaoId", "publicacaoId", comentarioModel.publicacaoId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "usuarioId", "usuarioId", comentarioModel.usuarioId);
            return View(comentarioModel);
        }

        // GET: Comentario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comentarios == null)
            {
                return NotFound();
            }

            var comentarioModel = await _context.Comentarios
                .Include(c => c.publicacao)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.comentarioId == id);
            if (comentarioModel == null)
            {
                return NotFound();
            }

            return View(comentarioModel);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comentarios == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.Comentarios'  is null.");
            }
            var comentarioModel = await _context.Comentarios.FindAsync(id);
            if (comentarioModel != null)
            {
                _context.Comentarios.Remove(comentarioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioModelExists(int id)
        {
          return (_context.Comentarios?.Any(e => e.comentarioId == id)).GetValueOrDefault();
        }
    }
}
