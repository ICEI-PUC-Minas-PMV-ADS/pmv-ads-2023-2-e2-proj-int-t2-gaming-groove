using System.Linq;
using GamingGroove.Data;
using GamingGroove.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public UsuarioModel getUsuarioLogado { get; set; }
        public UsuarioModel getEditUsuario { get; set; }
        public UsuarioModel getUsuarioAmizade { get; set; }
        public UsuarioModel getUsuarioPublicacao { get; set; }
        public UsuarioModel getUsuarioComentario { get; set; }
        public IEnumerable<UsuarioModel> getTodosUsuarios { get; set; }
        public IEnumerable<UsuarioModel> getSolicitantes { get; set; }
        public IEnumerable<UsuarioModel> getTodosUsuariosSolicitacoes { get; set; }
        public IEnumerable<UsuarioModel> getTodosUsuariosAmigos { get; set; }
        public IEnumerable<UsuarioModel> getTodosSolicitantes { get; set; }
        public int? IdUsuarioLogado { get; set; }


        public ComunidadeModel getComunidade { get; set; }
        public IEnumerable<ComunidadeModel> getComunidades { get; set; }
        public List<int> getComunidadesIds { get; set; }
        public ComunidadeModel getComunidadePublicacao { get; set; }
        public IEnumerable<ComunidadeModel> getTodasComunidades { get; set; }
        public IEnumerable<UsuarioComunidadeModel> getTodosUsuariosComunidades { get; set; }
        public IEnumerable<UsuarioComunidadeModel> getComunidadesSugeridas { get; set; }
        public IEnumerable<UsuarioComunidadeModel> getComunidadesUsuario { get; set; }
        public List<int> infoComunidades { get; set; }

        public IEnumerable<PublicacaoModel> getPublicacoes { get; set; }
        public IEnumerable<PublicacaoModel> getFeedPublicacoes { get; set; }
        public IEnumerable<PublicacaoModel> getTodasPublicacoes { get; set; }
        public PublicacaoModel getPublicacaoComentario { get; set; }
        

        public IEnumerable<EquipeModel> getEquipes { get; set; }
        public IEnumerable<UsuarioEquipeModel> getEquipesUsuario { get; set; }
        
        
        public IEnumerable<CurtidaModel> getTodasCurtidas { get; set; }
        public IEnumerable<CurtidaModel> getCurtidasPublicacao { get; set; }

        public IEnumerable<ComentarioModel> getTodosComentarios { get; set; }
        public IEnumerable<ComentarioModel> getComentariosPublicacao { get; set; }

        public IEnumerable<AmizadeModel> getTodasAmizades { get; set; }
        public IEnumerable<AmizadeModel> getAmizadesUsuario { get; set; }
        public IEnumerable<AmizadeModel> getSolicitacoes { get; set; }
        public AmizadeModel amizadeExistente { get; set; }
        
        

        public void OnGetListaDeAmigos(int? usuarioLogado)
        {
            getTodosUsuariosComunidades = _cc.UsuariosComunidades.ToList();

            getTodosUsuarios = _cc.Usuarios.ToList();
                        
            getTodasAmizades = _cc.Amizades.ToList();

            IdUsuarioLogado = usuarioLogado;

            getUsuarioLogado = _cc.Usuarios.FirstOrDefault(u => u.usuarioId == IdUsuarioLogado);

            getAmizadesUsuario = _cc.Amizades
                .Where(uc => uc.solicitanteId == IdUsuarioLogado || uc.receptorId == IdUsuarioLogado)
                .ToList(); 

            getAmizadesUsuario = getAmizadesUsuario
                .Where(uc => uc.estadoAmizade == EstadoAmizade.Aceita)
                .ToList();        

                    
            var amizadeUserIds = getAmizadesUsuario.SelectMany(amizade => new[] { amizade.solicitanteId, amizade.receptorId }).Distinct();

            getTodosUsuariosAmigos = _cc.Usuarios.Where(usuario => amizadeUserIds.Contains(usuario.usuarioId)).ToList();
            



            getSolicitacoes = _cc.Amizades
                .Where(uc => uc.receptorId == IdUsuarioLogado && uc.estadoAmizade == EstadoAmizade.Pendente && uc.solicitanteId != IdUsuarioLogado)
                .ToList();         

            var solicitacaoUserIds = getSolicitacoes.SelectMany(amizade => new[] { amizade.solicitanteId, amizade.receptorId }).Distinct();

            getTodosUsuariosSolicitacoes = _cc.Usuarios.Where(usuario => solicitacaoUserIds.Contains(usuario.usuarioId)).ToList();                

            getTodosUsuariosSolicitacoes = getTodosUsuariosSolicitacoes
                .Where(solicitacao => solicitacao.usuarioId != IdUsuarioLogado)
                .ToList();             

                
        }

        //PerfilPage
        public void OnGetPerfilPage(string user, int? usuarioLogado)
        {
            IdUsuarioLogado = usuarioLogado;

            getTodasAmizades = _cc.Amizades.ToList();

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

            amizadeExistente = _cc.Amizades
                .Where(a => 
                    (a.solicitante.usuarioId == getUsuario.usuarioId && a.receptor.usuarioId == IdUsuarioLogado) ||
                    (a.solicitante.usuarioId == IdUsuarioLogado && a.receptor.usuarioId == getUsuario.usuarioId))
                .FirstOrDefault();     
        }
     
        public void OnGetFeedPage(int? usuarioLogado)
        {
            IdUsuarioLogado = usuarioLogado;
            
            getTodosUsuarios = _cc.Usuarios.ToList();

            getTodasComunidades = _cc.Comunidades.ToList();

            getTodasCurtidas = _cc.Curtidas.ToList();

            getTodosComentarios = _cc.Comentarios.ToList();

            getTodasPublicacoes = _cc.Publicacoes.ToList();

            getEquipes = _cc.Equipes.ToList();

            getComunidadesUsuario = _cc.UsuariosComunidades
                .Where(uc => uc.usuarioId == IdUsuarioLogado)
                .Include(uc => uc.comunidade)
                .ToList();

            getComunidadesIds = getComunidadesUsuario.Select(uc => uc.comunidadeId).ToList();

            getFeedPublicacoes = _cc.Publicacoes
                .Where(p => getComunidadesIds.Contains(p.comunidadeId))
                .ToList();
            
            getEquipesUsuario = _cc.UsuariosEquipes
                .Where(ue => ue.usuarioId == IdUsuarioLogado)
                .Include(ue => ue.equipe)
                .ToList();                     

        }

        // ComunidadeHomePage + ComunidadePage 
        public void OnGetComunidadePages(string community, int? usuarioLogado)
        {            
            IdUsuarioLogado = usuarioLogado;

            getTodosUsuarios = _cc.Usuarios.ToList();

            getTodasComunidades = _cc.Comunidades.ToList();
            
            getTodosUsuariosComunidades = _cc.UsuariosComunidades.ToList();

            getTodasCurtidas = _cc.Curtidas.ToList();

            getTodosComentarios = _cc.Comentarios.ToList();

            getTodasPublicacoes = _cc.Publicacoes.ToList();


            getComunidade = _cc.Comunidades.FirstOrDefault(u => u.nomeComunidade == community);

            getUsuario = _cc.Usuarios.FirstOrDefault(u => u.usuarioId == IdUsuarioLogado);


            getComunidadesUsuario = _cc.UsuariosComunidades
                .Where(uc => uc.usuarioId == IdUsuarioLogado)
                .Include(uc => uc.comunidade)
                .ToList();            

            infoComunidades = getComunidadesUsuario.Select(ue => ue.comunidade.comunidadeId).ToList();
                            
            getComunidadesSugeridas = _cc.UsuariosComunidades
                .Where(uc => uc.usuarioId != IdUsuarioLogado && !infoComunidades.Contains(uc.comunidadeId))
                .Include(uc => uc.comunidade)
                .GroupBy(uc => uc.comunidadeId)
                .Select(group => group.First())
                .ToList();


            if(getComunidade != null)
            {
                getPublicacoes = _cc.Publicacoes
                    .Where(uc => uc.comunidadeId == getComunidade.comunidadeId)
                    .ToList(); 
            }         
                             
        }

        public int GetNumberOfMembersInCommunity(int _comunidadeId)
        {
            return _cc.UsuariosComunidades
                .Count(uc => uc.comunidadeId == _comunidadeId);
        }

        // ExplorarPage
        public void OnGetExplorarPage(int? usuario)
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
                .GroupBy(uc => uc.comunidadeId)
                .Select(group => group.First())
                .ToList(); 
        }
    

        // EquipePage
        public void OnGetEquipePage(int? usuario)
        {
            getEquipes = _cc.Equipes.ToList();
            
            getEquipesUsuario = _cc.UsuariosEquipes
                .Where(ue => ue.usuarioId == usuario)
                .Include(ue => ue.equipe)
                .ToList();       
        }


    }
}


