using Microsoft.AspNetCore.Mvc;
using GamingGroove.Data;
using GamingGroove.Models;
using GamingGroove.Views.Shared;

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
                var viewModel = new ViewModel(_context);
                

                if (viewModel == null)
                {
                    return NotFound();
                }

                var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
                viewModel.OnGetComunidadePages(community, usuarioId);
                

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

        public async Task<IActionResult> CriarComunidade(int? IdUsuario, string NomeComunidade, JogosEnum? PrimeiroJogo,
        JogosEnum? SegundoJogo, JogosEnum? TerceiroJogo, string DescricaoComunidade, DateTime dataCriacaoComunidade,
        IFormFile? iconeComunidadeArquivo, IFormFile? capaComunidadeArquivo)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            ComunidadeModel comunidadeModel = new ()
            {
                nomeComunidade = NomeComunidade,
                primeiroJogo = PrimeiroJogo,
                segundoJogo = SegundoJogo,
                terceiroJogo = TerceiroJogo,
                descricaoComunidade = DescricaoComunidade,
                dataCriacaoComunidade = DateTime.Now
            };


            if (ModelState.IsValid)
            {
                try
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

                    
                    if (IdUsuario.HasValue)
                    {
                        UsuarioComunidadeModel usuarioComunidadeModel = new ()
                        {
                            usuarioId = IdUsuario.Value,
                            comunidadeId = comunidadeModel.comunidadeId, 
                            cargoComunidade = CargosEnum.ADM,
                            dataVinculoComunidade = DateTime.Now
                        };

                        var ultimoUsuarioComunidadeId = _context.UsuariosComunidades
                            .OrderByDescending(uc => uc.usuarioComunidadeId)
                            .FirstOrDefault()?.usuarioComunidadeId ?? 0;

                        usuarioComunidadeModel.usuarioComunidadeId = ultimoUsuarioComunidadeId + 1;       

                        _context.Add(usuarioComunidadeModel);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "ComunidadePage", new { community = comunidadeModel.nomeComunidade });    
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Ocorreu um erro ao criar a comunidade: " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "*Preencha todos os campos adequadamente.";
            }


            return View("Create");
        }        
    }
}    