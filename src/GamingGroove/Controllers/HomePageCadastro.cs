using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GamingGroove.Data;
using System.Security.Claims;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    [AllowAnonymous]
    public class HomePageCadastroController : Controller
    {

        private readonly GamingGrooveDbContext _context;

        public HomePageCadastroController(GamingGrooveDbContext context)
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarConta([Bind("usuarioId,nomeUsuario,nomeCompleto,dataNascimento,email,senha,iconePerfil,capaPerfil,fotosGaleria,jogosFavoritos,biografia,registrationDate,tipoUsuario")] UsuarioModel usuarioModel)
        {
            var existingUser = _context.Usuarios.FirstOrDefault(uc => uc.nomeUsuario == usuarioModel.nomeUsuario);
            var existingEmail = _context.Usuarios.FirstOrDefault(uc => uc.email == usuarioModel.email);

            if(existingUser != null)
            {
                ViewBag.Message = "O nome de usuário já existe.";
            }
            else
            {
                if(existingEmail != null){
                    ViewBag.Message2 = "Já existe uma conta com o e-mail informado.";
                }
                else
                {
                    if(string.IsNullOrEmpty(usuarioModel.nomeUsuario) || usuarioModel.nomeUsuario.Length < 6 || usuarioModel.nomeUsuario.Length > 14)
                    {
                        ViewBag.Message = "O nome de usuário deve ter entre 6 e 14 caracteres.";
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(usuarioModel.senha) || usuarioModel.senha.Length < 8)
                        {
                            ViewBag.PasswordMessage = "A senha deve ter ao menos 6 caracteres.";
                        }
                        else
                        {
                            if (ModelState.IsValid)
                            {
                                usuarioModel.primeiroJogo = JogosEnum.Nenhum;
                                usuarioModel.segundoJogo = JogosEnum.Nenhum;
                                usuarioModel.terceiroJogo = JogosEnum.Nenhum;

                                usuarioModel.senha = BCrypt.Net.BCrypt.HashPassword(usuarioModel.senha);                       
                                _context.Add(usuarioModel);
                                await _context.SaveChangesAsync();
                                return RedirectToAction("Index", "HomePageLogin");
                            }   
                        }
                    }                 
                }                
            }
            return View("Index", usuarioModel);
        }

                
        [HttpGet]
        public IActionResult GetIconeUsuario()
        {           
            var UsuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _context.Usuarios.FirstOrDefault(u => u.usuarioId == int.Parse(UsuarioID));
            string IconePadrao = "images/icons/user-standard.png";

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
 