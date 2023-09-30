using Microsoft.EntityFrameworkCore;
using GamingGroove.Models;

namespace GamingGroove.Data
{
    public class GamingGrooveDbContext : DbContext
    {

        public GamingGrooveDbContext(DbContextOptions<GamingGrooveDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<AmizadeModel> Amizades { get; set; }
        public DbSet<ChatModel> Chats { get; set; }
        public DbSet<ComentarioModel> Comentarios { get; set; }
        public DbSet<ComunidadeModel> Comunidades { get; set; }
        public DbSet<CurtidaModel> Curtidas { get; set; }
        public DbSet<DenunciaModel> Denuncias { get; set; }
        public DbSet<EquipeModel> Equipes { get; set; }
        public DbSet<PublicacaoModel> Publicacoes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        
        public DbSet<UsuarioComunidadeModel> UsuariosComunidades { get; set; }
        public DbSet<UsuarioEquipeModel> UsuariosEquipes { get; set; }
        
    }
}