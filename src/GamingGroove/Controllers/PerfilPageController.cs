using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Views.PerfilPage;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class PerfilPageController : BaseController
    {
        private readonly GamingGrooveDbContext _contexto;

        public PerfilPageController(GamingGrooveDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index(string user)
        {
            var viewModel = new PerfilPageViewModel(_contexto);
            viewModel.OnGet(user);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _contexto.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioModel = await _contexto.Usuarios.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return View(usuarioModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioModel usuarioModel, IFormFile? iconePerfilArquivo, IFormFile? capaPerfilArquivo)
        {
            if (id != usuarioModel.usuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingCommunity = await _contexto.Usuarios.FindAsync(id);

                    if (existingCommunity != null)
                    {
                        existingCommunity.nomeUsuario = usuarioModel.nomeUsuario;
                        existingCommunity.primeiroJogo = usuarioModel.primeiroJogo;
                        existingCommunity.segundoJogo = usuarioModel.segundoJogo;
                        existingCommunity.terceiroJogo = usuarioModel.terceiroJogo;
                        existingCommunity.biografia = usuarioModel.biografia;

                        if (iconePerfilArquivo != null && iconePerfilArquivo.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await iconePerfilArquivo.CopyToAsync(memoryStream);
                                existingCommunity.iconePerfil = memoryStream.ToArray();
                            }
                        }

                        if (capaPerfilArquivo != null && capaPerfilArquivo.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await capaPerfilArquivo.CopyToAsync(memoryStream);
                                existingCommunity.capaPerfil = memoryStream.ToArray();
                            }
                        }

                        _contexto.Entry(existingCommunity).State = EntityState.Modified;
                        await _contexto.SaveChangesAsync();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.usuarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "PerfilPage", new { user = usuarioModel.nomeUsuario });
            }
            return View(usuarioModel);
        }

        private bool UsuarioModelExists(int id)
        {
          return (_contexto.Usuarios?.Any(e => e.usuarioId == id)).GetValueOrDefault();
        }
    }
}
