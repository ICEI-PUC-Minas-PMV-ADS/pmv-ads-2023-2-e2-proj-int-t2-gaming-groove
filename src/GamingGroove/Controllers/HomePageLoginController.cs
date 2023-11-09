using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GamingGroove.Data;
using GamingGroove.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace GamingGroove.Controllers
{
    [AllowAnonymous]
    public class HomePageLoginController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public HomePageLoginController(GamingGrooveDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {           
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "FeedPage");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioModel usuarioLogin)
        {
            var dados = await _context.Usuarios
            .Where(u => u.nomeUsuario == usuarioLogin.nomeUsuario)
            .FirstOrDefaultAsync();

            if(dados == null || usuarioLogin.senha == null)
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

                HttpContext.Session.SetInt32("UsuarioId", dados.usuarioId);
                
                return RedirectToAction("Index","FeedPage");

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
            return RedirectToAction("Index", "HomePageLogin");
        }
    }
}