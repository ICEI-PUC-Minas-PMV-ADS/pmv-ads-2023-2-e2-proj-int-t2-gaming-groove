using GamingGroove.Data;
using GamingGroove.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Modes;

namespace GamingGroove.Views.PerfilPage
{
    public class PerfilPageViewModel : PageModel
    {
        private readonly GamingGrooveDbContext _cc;

        public PerfilPageViewModel(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }

        public UsuarioModel getUsuario { get; set; }
        public IEnumerable<UsuarioEquipeModel> getEquipes { get; set; }
        public IEnumerable<UsuarioComunidadeModel> getComunidades { get; set; }

        public void OnGet(string user)
        {
            getUsuario = _cc.Usuarios.FirstOrDefault(u => u.nomeUsuario == user);

            if (getUsuario != null)
            {
                getEquipes = _cc.UsuariosEquipes
                    .Where(ue => ue.usuarioId == getUsuario.usuarioId)
                    .Include(ue => ue.equipe)
                    .ToList();

                getComunidades = _cc.UsuariosComunidades
                    .Where(uc => uc.usuarioId == getUsuario.usuarioId)
                    .Include(uc => uc.comunidade)
                    .ToList();
            }
        }
    }
}