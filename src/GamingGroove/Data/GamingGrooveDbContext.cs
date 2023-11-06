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
                .HasForeignKey(a => a.solicitanteId);

            modelBuilder.Entity<AmizadeModel>()
                .HasOne(a => a.receptor)
                .WithMany(u => u.receptorAmizade)
                .HasForeignKey(a => a.receptorId);

            modelBuilder.Entity<CurtidaModel>()
                .HasOne(a => a.usuario)
                .WithMany(u => u.usuarioCurtida)
                .HasForeignKey(a => a.usuarioId);

            modelBuilder.Entity<CurtidaModel>()
                .HasOne(a => a.publicacao)
                .WithMany(u => u.publicacaoCurtida)
                .HasForeignKey(a => a.publicacaoId);

            modelBuilder.Entity<DenunciaModel>()
                .HasOne(a => a.denunciante)
                .WithMany(u => u.denuncianteDenuncia)
                .HasForeignKey(a => a.denuncianteId);

            modelBuilder.Entity<DenunciaModel>()
                .HasOne(a => a.denunciado)
                .WithMany(u => u.denunciadoDenuncia)
                .HasForeignKey(a => a.denunciadoId);


            modelBuilder.Entity<UsuarioComunidadeModel>()
                .HasKey(pc => new { pc.usuarioId, pc.comunidadeId });

            modelBuilder.Entity<UsuarioComunidadeModel>()
                .HasOne(pc => pc.usuario)
                .WithMany(p => p.usuarioComunidade)
                .HasForeignKey(pc => pc.usuarioId);

            modelBuilder.Entity<UsuarioComunidadeModel>()
                .HasOne(pc => pc.comunidade)
                .WithMany(c => c.usuarioComunidade)
                .HasForeignKey(pc => pc.comunidadeId);                


            modelBuilder.Entity<UsuarioEquipeModel>()
                .HasKey(pc => new { pc.usuarioId, pc.equipeId });

            modelBuilder.Entity<UsuarioEquipeModel>()
                .HasOne(pc => pc.usuario)
                .WithMany(p => p.usuarioEquipe)
                .HasForeignKey(pc => pc.usuarioId);

            modelBuilder.Entity<UsuarioEquipeModel>()
                .HasOne(pc => pc.equipe)
                .WithMany(c => c.usuarioEquipe)
                .HasForeignKey(pc => pc.equipeId);                   
        }
        
    }
}