using System.Security.Claims;
using GamingGroove.Data;
using GamingGroove.Models;
using GamingGroove.Views.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingGroove.Controllers
{
    public class EquipePageController : BaseController
    {
        private readonly GamingGrooveDbContext _cc;

        public EquipePageController(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            var viewModel = new ViewModel(_cc);
            var IdUsuarioLogado = HttpContext.Session.GetInt32("UsuarioId");

            viewModel.OnGetListaDeAmigos(IdUsuarioLogado);
            viewModel.OnGetEquipePage(IdUsuarioLogado);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }


       

        public async Task<IActionResult> CriarEquipe(int? IdUsuario, string NomeEquipe, JogosEnum JogoEquipe,string DescricaoEquipe, DateTime dataCriacaoEquipe,
        IFormFile? iconeEquipeArquivo) 
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");


            EquipeModel equipeModel = new()
            {
                nomeEquipe = NomeEquipe,
                jogoEquipe = JogoEquipe,
                descricaoEquipe = DescricaoEquipe,
                dataCriacaoEquipe = DateTime.Now
            };

            var existingEquipe = await _cc.Equipes.FirstOrDefaultAsync(c => c.nomeEquipe == equipeModel.nomeEquipe);

            if (existingEquipe != null)
            {
                TempData["ErrorMessage"] = "O nome de equipe fornecido ja existe. Escolha outro e tente novamente.";
                return RedirectToAction("Index", equipeModel);
            }


            if (ModelState.IsValid)
            {
                try
                {
                    if (iconeEquipeArquivo != null && iconeEquipeArquivo.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await iconeEquipeArquivo.CopyToAsync(memoryStream);
                            equipeModel.iconeEquipe = memoryStream.ToArray();
                        }
                    }

                   

                    _cc.Add(equipeModel);
                    await _cc.SaveChangesAsync();
                    return RedirectToAction("Index", "EquipePage");

                    
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Ocorreu um erro ao criar a comunidade: " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Todos os campos sao obrigatorios. Tente novamente.";
            }


            return RedirectToAction("Index", equipeModel);
        }
    }

}
