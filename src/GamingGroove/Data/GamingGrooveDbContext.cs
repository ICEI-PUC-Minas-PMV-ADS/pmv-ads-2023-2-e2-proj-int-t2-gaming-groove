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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmizadeModel>()
                .HasOne(a => a.solicitante)
                .WithMany(u => u.solicitanteAmizade)
                .HasForeignKey(a => a.solicitanteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AmizadeModel>()
                .HasOne(a => a.receptor)
                .WithMany(u => u.receptorAmizade)
                .HasForeignKey(a => a.receptorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CurtidaModel>()
                .HasOne(a => a.usuario)
                .WithMany(u => u.usuarioCurtida)
                .HasForeignKey(a => a.usuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CurtidaModel>()
                .HasOne(a => a.publicacao)
                .WithMany(u => u.publicacaoCurtida)
                .HasForeignKey(a => a.publicacaoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DenunciaModel>()
                .HasOne(a => a.denunciante)
                .WithMany(u => u.denuncianteDenuncia)
                .HasForeignKey(a => a.denuncianteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DenunciaModel>()
                .HasOne(a => a.denunciado)
                .WithMany(u => u.denunciadoDenuncia)
                .HasForeignKey(a => a.denunciadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
    }
}