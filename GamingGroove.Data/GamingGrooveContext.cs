using Microsoft.EntityFrameworkCore;
using GamingGroove.Data.Models;

namespace GamingGroove.Data
{
    public class GamingGrooveContext : DbContext
    {
        public GamingGrooveContext(DbContextOptions<GamingGrooveContext> options) : base(options)
        {
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Comunidade>? Comunidades { get; set; }
        public DbSet<Equipe>? Equipes { get; set; }
        public DbSet<Chat>? Chats { get; set; }
        public DbSet<Mensagem>? Mensagens { get; set; }
    }
}