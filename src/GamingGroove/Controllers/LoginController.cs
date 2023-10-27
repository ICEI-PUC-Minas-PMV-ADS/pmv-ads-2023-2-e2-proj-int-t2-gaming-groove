using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace GamingGroove.Controllers
{
    [AllowAnonymous]
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

                
        [HttpGet]
        public IActionResult GetIconeUsuario()
        {           
            var UsuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _context.Usuarios.FirstOrDefault(u => u.usuarioId == int.Parse(UsuarioID));
            string IconePadrao = "images/icons/empty-icon.png";

            var cacheProfile = new CacheProfile
            {
                NoStore = true,   
                Duration = 0  
            };

            Response.Headers.Add("Cache-Control", "no-store, max-age=0");

            if (user != null && user.iconePerfil != null)
            {
                return File(user.iconePerfil, "image/png");
            }

            return File(IconePadrao, "image/png");
        }
    }
}