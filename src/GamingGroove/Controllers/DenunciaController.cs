using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class DenunciaController : BaseController
    {
        private readonly GamingGrooveDbContext _context;

        public DenunciaController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DenunciarUsuario(int? Denunciante, int DenunciadoId, string DescricaoDenuncia, TiposDenuncia TipoDenuncia)
        {
            Denunciante = HttpContext.Session.GetInt32("UsuarioId");

            DenunciaModel denunciaModel = new ()
            {
                denuncianteId = (int)Denunciante,
                denunciadoId = DenunciadoId,
                publicacaoId = null,
                comunidadeId = null,
                descricaoDenuncia = DescricaoDenuncia,
                TipoDenuncia = TipoDenuncia,
                situacaoDenuncia = SituacaoDenuncia.Aberta,
                dataDenuncia = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                _context.Add(denunciaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PerfilPage", new { user = TempData["UserValue"]});
            }
            return RedirectToAction("Index", "PerfilPage", new { user = TempData["UserValue"]});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DenunciarComunidade(int? Denunciante, int ComunidadeId, string DescricaoDenuncia, TiposDenuncia TipoDenuncia, string NomeComunidade)
        {
            Denunciante = HttpContext.Session.GetInt32("UsuarioId");

            DenunciaModel denunciaModel = new ()
            {
                denuncianteId = (int)Denunciante,
                denunciadoId = null,
                publicacaoId = null,
                comunidadeId = ComunidadeId,
                descricaoDenuncia = DescricaoDenuncia,
                TipoDenuncia = TipoDenuncia,
                situacaoDenuncia = SituacaoDenuncia.Aberta,
                dataDenuncia = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                _context.Add(denunciaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ComunidadePage", new { community = NomeComunidade });
            }
            return RedirectToAction("Index", "ComunidadePage", new { community = NomeComunidade });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DenunciarPublicacao(int? Denunciante, int PublicacaoId, string DescricaoDenuncia, TiposDenuncia TipoDenuncia, string NomeComunidade)
        {
            Denunciante = HttpContext.Session.GetInt32("UsuarioId");

            DenunciaModel denunciaModel = new ()
            {
                denuncianteId = (int)Denunciante,
                denunciadoId = null,
                publicacaoId = PublicacaoId,
                comunidadeId = null,
                descricaoDenuncia = DescricaoDenuncia,
                TipoDenuncia = TipoDenuncia,
                situacaoDenuncia = SituacaoDenuncia.Aberta,
                dataDenuncia = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                _context.Add(denunciaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ComunidadePage", new { community = NomeComunidade });
            }
            return RedirectToAction("Index", "ComunidadePage", new { community = NomeComunidade });
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
