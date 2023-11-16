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
        private readonly GamingGrooveDbContext _context;

        public EquipePageController(GamingGrooveDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var viewModel = new ViewModel(_context);
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

            


            var existingEquipe = await _context.Equipes.FirstOrDefaultAsync(c => c.nomeEquipe == equipeModel.nomeEquipe);

            if(string.IsNullOrEmpty(equipeModel.nomeEquipe) || equipeModel.nomeEquipe.Length < 6 || equipeModel.nomeEquipe.Length > 16)
            {
                TempData["ErrorMessageCharsNumber"] = "O nome de sua equipe deve ter entre 6 e 16 caracteres.";
                return RedirectToAction("Index", equipeModel);
            }

            if (existingEquipe != null)
            {
                TempData["ErrorMessageRepeatedName"] = "O nome de equipe fornecido ja existe. Escolha outro e tente novamente.";
                return RedirectToAction("Index", equipeModel);
            }

            if (equipeModel.descricaoEquipe == null)
            {
                TempData["ErrorMessageEmptyDescription"] = "O campo de descricao da equipe e obrigatorio.";
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

                   

                    _context.Add(equipeModel);
                    await _context.SaveChangesAsync();
                    
                    if (IdUsuario.HasValue)
                    {
                        UsuarioEquipeModel usuarioEquipeModel = new ()
                        {
                            usuarioId = IdUsuario.Value,
                            equipeId = equipeModel.equipeId, 
                            cargoEquipe = CargosEnum.ADM,
                            dataVinculoEquipe = DateTime.Now
                        };

                        var ultimoUsuarioEquipeId = _context.UsuariosEquipes
                            .OrderByDescending(uc => uc.usuarioEquipeId)
                            .FirstOrDefault()?.usuarioEquipeId ?? 0;

                        usuarioEquipeModel.usuarioEquipeId = ultimoUsuarioEquipeId + 1;       

                        _context.Add(usuarioEquipeModel);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Index", "EquipePage");    
                    }
                    
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

        public async Task<IActionResult> IngressarEquipe(int? IdUsuario, int IdEquipe)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            UsuarioEquipeModel usuarioEquipeModel = new ()
            {
                usuarioId = (int)IdUsuario,
                equipeId = IdEquipe,
                cargoEquipe = CargosEnum.Membro,
                dataVinculoEquipe = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                var ultimoUsuarioEquipeId = _context.UsuariosEquipes
                    .OrderByDescending(uc => uc.usuarioEquipeId)
                    .FirstOrDefault()?.usuarioEquipeId ?? 0;

                usuarioEquipeModel.usuarioEquipeId = ultimoUsuarioEquipeId + 1;

                _context.Add(usuarioEquipeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "EquipePage");
            }

            return RedirectToAction("Index", "EquipePage");
        }

        public async Task<IActionResult> DeixarEquipe(int? IdUsuario, int IdEquipe)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var usuarioEquipeModel = await _context.UsuariosEquipes
                .FirstOrDefaultAsync(uc => uc.usuarioId == IdUsuario && uc.equipeId == IdEquipe);

            _context.UsuariosEquipes.Remove(usuarioEquipeModel);     

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "EquipePage");            
        }

        public async Task<IActionResult> ApagarEquipe(int? IdUsuario, int IdEquipe)
        {
            IdUsuario = HttpContext.Session.GetInt32("UsuarioId");

            var equipeModel = await _context.Equipes
                .FirstOrDefaultAsync(uc => uc.equipeId == IdEquipe);

            _context.Equipes.Remove(equipeModel);     

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "EquipePage");           
        }    


        public async Task<IActionResult> EditarEquipe(int? EquipeId, string NomeEquipe, JogosEnum JogoEquipe, 
        string DescricaoEquipe, IFormFile iconeEquipeArquivo)
        {
            var existingTeam = await _context.Equipes.FindAsync(EquipeId);

            if(string.IsNullOrEmpty(NomeEquipe) || NomeEquipe.Length < 6 || NomeEquipe.Length > 16)
            {
                TempData["ErrorMessageCharsNumber"] = "O nome de sua equipe deve ter entre 6 e 16 caracteres.";
                return RedirectToAction("Index", "EquipePage");
            }


            var existingTeamName = _context.Equipes.FirstOrDefault(uc => uc.nomeEquipe == NomeEquipe);
            
            if (existingTeam != null && existingTeamName != null && existingTeamName.nomeEquipe != null && existingTeamName.nomeEquipe != existingTeam.nomeEquipe)
            {
                TempData["ErrorMessageRepeatedName"] = "O nome de equipe fornecido ja existe. Escolha outro e tente novamente.";
                return RedirectToAction("Index", "EquipePage");
            }

            if(existingTeam != null)
            {
                existingTeam.nomeEquipe = NomeEquipe;
                existingTeam.jogoEquipe = JogoEquipe;
                existingTeam.descricaoEquipe = DescricaoEquipe;

                if (iconeEquipeArquivo != null && iconeEquipeArquivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await iconeEquipeArquivo.CopyToAsync(memoryStream);
                        existingTeam.iconeEquipe = memoryStream.ToArray();
                    }
                }
                
                if (existingTeam.descricaoEquipe == null)
                {
                    TempData["ErrorMessageEmptyDescription"] = "O campo de descricao da equipe e obrigatorio.";
                    return RedirectToAction("Index", "EquipePage");
                }

                 _context.Entry(existingTeam).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("Index", "EquipePage");
        }       
    }

}
