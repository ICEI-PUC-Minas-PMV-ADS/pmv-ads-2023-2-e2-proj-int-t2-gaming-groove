using GamingGroove.Data;
using GamingGroove.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GamingGroove.Views.EquipePage
{
    public class EquipePageViewModel : PageModel
    {
        private readonly GamingGrooveDbContext _cc;

        public EquipePageViewModel(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }

        public IEnumerable<EquipeModel> getEquipes { get; set; }
        public UsuarioModel getUsuario { get; set; }
        public IEnumerable<UsuarioEquipeModel> getEquipesUsuario { get; set; }
        public List<string> InfoEquipes { get; set; }

        public List<string> InfoEquipes2 { get; set; }

        public void GetEquipesUsuario(int usuario)
        {

            getEquipes = _cc.Equipes.ToList();
            
            getEquipesUsuario = _cc.UsuariosEquipes
                .Where(ue => ue.usuarioId == usuario)
                .Include(ue => ue.equipe)
                .ToList();        

            InfoEquipes = getEquipesUsuario.Select(ue => ue.equipe.nomeEquipe).ToList();
            InfoEquipes = getEquipesUsuario.Select(ue => ue.equipe.jogoEquipe.ToString()).ToList();
            InfoEquipes = getEquipesUsuario.Select(ue => ue.equipe.descricaoEquipe).ToList();

            InfoEquipes2 = getEquipes.Select(ue => ue.nomeEquipe).ToList();
        }
    }
}