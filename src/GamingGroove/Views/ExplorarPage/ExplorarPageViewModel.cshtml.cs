using GamingGroove.Data;
using GamingGroove.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace GamingGroove.Views.ExplorarPage
{
    public class ExplorarPageViewModel : PageModel
    {
        private readonly GamingGrooveDbContext _cc;
    
        public ExplorarPageViewModel(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }

        //Comunidades//
        public IEnumerable<ComunidadeModel> getComunidades{ get; set; }
        public UsuarioModel getUsuario { get; set; }
        public IEnumerable<UsuarioComunidadeModel> getComunidadesUsuario { get; set; }
        public List<string> InfoComunidade { get; set; }
        public List<string> InfoComunidade2 { get; set; }

        public void GetExplorar(int usuario)
        {

            getComunidades = _cc.Comunidades.ToList();
            
            getComunidadesUsuario = _cc.UsuariosComunidades
                .Where(ex => ex.usuarioId == usuario)
                .Include(ex => ex.comunidade)
                .ToList();        

            InfoComunidade = getComunidadesUsuario.Select(ex => ex.comunidade.nomeComunidade).ToList();
            

            InfoComunidade2 = getComunidades.Select(ex => ex.nomeComunidade).ToList();
        }




        //EQUIPES//

        
    }
}