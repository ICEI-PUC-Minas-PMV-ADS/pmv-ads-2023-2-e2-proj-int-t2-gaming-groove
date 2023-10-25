using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Models;
using Microsoft.AspNetCore.Authorization;

namespace GamingGroove.Controllers
{
    [AllowAnonymous]
    public class CadastroController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public CadastroController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("usuarioId,nomeUsuario,nomeCompleto,dataNascimento,email,senha,iconePerfil,capaPerfil,fotosGaleria,jogosFavoritos,biografia,registrationDate,tipoUsuario")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioModel.senha = BCrypt.Net.BCrypt.HashPassword(usuarioModel.senha);
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Login");
            }

            return View("Login");
        }


    }
}    