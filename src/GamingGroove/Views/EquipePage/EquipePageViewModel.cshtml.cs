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

        public void Teste(string user)
        {
            var IdUsuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var equipesUsuario = _cc.UsuariosEquipes
                .Where(ue => ue.usuarioId == IdUsuario)
                .Include(ue => ue.equipe)
                .ToList();
            
        }

        internal void OnGet(string user)
        {
            throw new NotImplementedException();
        }
    }
}