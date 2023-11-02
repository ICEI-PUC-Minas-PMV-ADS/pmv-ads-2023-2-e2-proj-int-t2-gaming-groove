using GamingGroove.Data;
using GamingGroove.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GamingGroove.Views.Shared
{
    public class ViewModel : PageModel
    {
        private readonly GamingGrooveDbContext _cc;

        public ViewModel(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }

        public UsuarioModel getUsuario { get; set; }
        public IEnumerable<UsuarioModel> getTodosUsuarios { get; set; }
        public int? IdUsuarioLogado { get; set; }


        public ComunidadeModel getComunidade { get; set; }
        public IEnumerable<ComunidadeModel> getComunidades { get; set; }
        public List<ComunidadeModel> getTodasComunidades { get; set; }
        public IEnumerable<UsuarioComunidadeModel> getComunidadesSugeridas { get; set; }
        public IEnumerable<UsuarioComunidadeModel> getComunidadesUsuario { get; set; }
        public List<int> infoComunidades { get; set; }
        

        public IEnumerable<EquipeModel> getEquipes { get; set; }
        public IEnumerable<UsuarioEquipeModel> getEquipesUsuario { get; set; }
        

        

        //PerfilPage
        public void OnGetPerfilPage(string user)
        {
            getUsuario = _cc.Usuarios.FirstOrDefault(u => u.nomeUsuario == user);

            if (getUsuario != null)
            {
                getEquipesUsuario = _cc.UsuariosEquipes
                    .Where(ue => ue.usuarioId == getUsuario.usuarioId)
                    .Include(ue => ue.equipe)
                    .ToList();  

                getComunidadesUsuario = _cc.UsuariosComunidades
                    .Where(uc => uc.usuarioId == getUsuario.usuarioId)
                    .Include(uc => uc.comunidade)
                    .ToList();
            }
        }



        // ComunidadeHomePage + ComunidadePage 
        public void OnGetComunidadePages(string community, int? usuarioLogado)
        {            
            IdUsuarioLogado = usuarioLogado;

            getComunidade = _cc.Comunidades.FirstOrDefault(u => u.nomeComunidade == community);

            getTodasComunidades = _cc.Comunidades.ToList();

            getUsuario = _cc.Usuarios.FirstOrDefault(u => u.usuarioId == IdUsuarioLogado);

            getComunidadesUsuario = _cc.UsuariosComunidades
                .Where(uc => uc.usuarioId == IdUsuarioLogado)
                .Include(uc => uc.comunidade)
                .ToList();            

            infoComunidades = getComunidadesUsuario.Select(ue => ue.comunidade.comunidadeId).ToList();
                            
            getComunidadesSugeridas = _cc.UsuariosComunidades
                .Where(uc => uc.usuarioId != IdUsuarioLogado && !infoComunidades.Contains(uc.comunidadeId))
                .Include(uc => uc.comunidade)
                .ToList();   
        }

        public int GetNumberOfMembersInCommunity(int _comunidadeId)
        {
            return _cc.UsuariosComunidades
                .Count(uc => uc.comunidadeId == _comunidadeId);
        }



        // ExplorarPage
        public void OnGetExplorarPage(int usuario)
        {                      
            getTodosUsuarios = _cc.Usuarios.ToList();


            getComunidadesUsuario = _cc.UsuariosComunidades
                .Where(ex => ex.usuarioId == usuario)
                .Include(ex => ex.comunidade)
                .ToList();      

            
            infoComunidades = getComunidadesUsuario.Select(ue => ue.comunidade.comunidadeId).ToList();

            getComunidadesSugeridas = _cc.UsuariosComunidades
                .Where(uc => uc.usuarioId != IdUsuarioLogado && !infoComunidades.Contains(uc.comunidadeId))
                .Include(uc => uc.comunidade)
                .ToList();  
        }
    


        public void OnGetEquipePage(int usuario)
        {
            getEquipes = _cc.Equipes.ToList();
            
            getEquipesUsuario = _cc.UsuariosEquipes
                .Where(ue => ue.usuarioId == usuario)
                .Include(ue => ue.equipe)
                .ToList();       
        }
    }
}