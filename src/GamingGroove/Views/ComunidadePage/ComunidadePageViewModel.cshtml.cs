using GamingGroove.Data;
using GamingGroove.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Modes;

namespace GamingGroove.Views.ComunidadePage
{
    public class ComunidadePageViewModel : PageModel
    {
        private readonly GamingGrooveDbContext _cc;

        public ComunidadePageViewModel(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }

        public ComunidadeModel getComunidade { get; set; }
        public List<ComunidadeModel> getMembrosComunidade { get; set; }
        public List<ComunidadeModel> getTodasComunidades { get; set; }
        public IEnumerable<UsuarioComunidadeModel> getComunidades { get; set; }
        public List<string> infoComunidades { get; set; }

        public void OnGet(string community)
        {
            getComunidade = _cc.Comunidades.FirstOrDefault(u => u.nomeComunidade == community);

            getMembrosComunidade = _cc.Comunidades
                    .Where(uc => uc.nomeComunidade == getComunidade.nomeComunidade)
                    .ToList();

            getTodasComunidades = _cc.Comunidades.ToList();
        }            

        public int GetNumberOfMembersInCommunity( int _comunidadeId)
        {
            return _cc.UsuariosComunidades
                .Count(uc => uc.comunidadeId == _comunidadeId);
        }
    }
}