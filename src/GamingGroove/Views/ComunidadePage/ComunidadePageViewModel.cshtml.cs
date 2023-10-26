using GamingGroove.Data;
using GamingGroove.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace GamingGroove.Views.ComunidadePage
{
    public class ComunidadePageViewModel : PageModel
    {
        private readonly GamingGrooveDbContext _cc;

        public ComunidadePageViewModel(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }

        public IEnumerable<EquipeModel> getEquipes { get; set; }
        public IEnumerable<UsuarioEquipeModel> getEquipesUsuario { get; set; }
        
        public void GetComunidadesUsuario(int usuario)
        {
            
        }
    }
}