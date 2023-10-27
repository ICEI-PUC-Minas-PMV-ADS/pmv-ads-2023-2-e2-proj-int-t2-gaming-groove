using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Views.PerfilPage;
using GamingGroove.Models;
using System.Security.Claims;

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
            if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value == id.ToString())
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
            else
            {
                return RedirectToAction("Index", "AcessoNegadoPage");
            }  
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
                    var existingUser = await _contexto.Usuarios.FindAsync(id);

                    if (existingUser != null)
                    {

                        existingUser.primeiroJogo = usuarioModel.primeiroJogo;
                        existingUser.segundoJogo = usuarioModel.segundoJogo;
                        existingUser.terceiroJogo = usuarioModel.terceiroJogo;
                        existingUser.biografia = usuarioModel.biografia;

                        if (iconePerfilArquivo != null && iconePerfilArquivo.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await iconePerfilArquivo.CopyToAsync(memoryStream);
                                existingUser.iconePerfil = memoryStream.ToArray();
                            }
                        }

                        if (capaPerfilArquivo != null && capaPerfilArquivo.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await capaPerfilArquivo.CopyToAsync(memoryStream);
                                existingUser.capaPerfil = memoryStream.ToArray();
                            }
                        }

                        usuarioModel.nomeUsuario = existingUser.nomeUsuario;
                        usuarioModel.nomeCompleto = existingUser.nomeCompleto;
                        usuarioModel.dataNascimento = existingUser.dataNascimento;
                        usuarioModel.email = existingUser.email;
                        usuarioModel.senha = existingUser.senha;

                        _contexto.Entry(existingUser).State = EntityState.Modified;
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
            else
            {
        }
        return View(usuarioModel);
        }

        private bool UsuarioModelExists(int id)
        {
          return (_contexto.Usuarios?.Any(e => e.usuarioId == id)).GetValueOrDefault();
        }
    }
}
