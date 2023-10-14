using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace GamingGroove
{
    public class LoginController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public LoginController(GamingGrooveDbContext context)
        {
            _context = context;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioModel usuarioLogin)
        {
            var dados = await _context.Usuarios
            .Where(u => u.nomeUsuario == usuarioLogin.nomeUsuario)
            .FirstOrDefaultAsync();

            if(dados == null)
            {
                ViewBag.Message = "Usuário e/o senha inválido(s).";
                return View("Index");
            }

            bool senhaOK = BCrypt.Net.BCrypt.Verify(usuarioLogin.senha, dados.senha);

            if (senhaOK)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.nomeUsuario),
                    new Claim(ClaimTypes.NameIdentifier, dados.usuarioId.ToString()),
                    new Claim(ClaimTypes.Email, dados.email),
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };
                
                await HttpContext.SignInAsync(principal, props);
                
                return RedirectToAction("Index","ProfilePage");

            }
            else 
            {
                ViewBag.Message = "Usuário e/o senha inválido(s).";
            }

            return View("Index");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "HomePage");
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
                return RedirectToAction("Index", "HomePage");
            }

            return View("Index", usuarioModel);
        }
    }
}