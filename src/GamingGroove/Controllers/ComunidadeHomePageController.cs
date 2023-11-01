using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Views.ComunidadeHomePage;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class ComunidadeHomePageController : BaseController
    {
        private readonly GamingGrooveDbContext _context;

        public ComunidadeHomePageController(GamingGrooveDbContext context)
        {
            _context = context;
        }



        public IActionResult Index(string community)
        {
            {
                var viewModel = new ComunidadeHomePageViewModel(_context);
                

                if (viewModel == null)
                {
                    return NotFound();
                }

                var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
                
                if (usuarioId.HasValue)
                {
                   usuarioId = usuarioId.Value;
                }
                                viewModel.OnGet(community);
                viewModel.GetUsuarioLogado(usuarioId);

                

                return View(viewModel);
            }
        }
        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("comunidadeId,nomeComunidade,iconeComunidade,capaComunidade,primeiroJogo,segundoJogo,terceiroJogo,descricaoComunidade,dataCriacaoComunidade")] ComunidadeModel comunidadeModel, IFormFile? iconeComunidadeArquivo, IFormFile? capaComunidadeArquivo)
        {
            if (ModelState.IsValid)
            {
                if (iconeComunidadeArquivo != null && iconeComunidadeArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await iconeComunidadeArquivo.CopyToAsync(memoryStream);
                        comunidadeModel.iconeComunidade = memoryStream.ToArray();
                    }
                }

                if (capaComunidadeArquivo != null && capaComunidadeArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await capaComunidadeArquivo.CopyToAsync(memoryStream);
                        comunidadeModel.capaComunidade = memoryStream.ToArray();
                    }   
                }      
                       
                _context.Add(comunidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ComunidadePage", new { community = comunidadeModel.nomeComunidade });
            }
            return View("comunidadeModel");
        }        
    }
}    